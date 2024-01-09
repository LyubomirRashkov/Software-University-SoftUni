using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.RePlay
{
	public class RePlayer : IRePlayer
	{
		private readonly SortedDictionary<string, Dictionary<string, Track>> tracksByAlbumName;

		private readonly Dictionary<string, Track> tracksById;

		private Queue<Track> listeningQueue;

		public RePlayer()
		{
			this.tracksByAlbumName = new SortedDictionary<string, Dictionary<string, Track>>();
			this.tracksById = new Dictionary<string, Track>();
			this.listeningQueue = new Queue<Track>();
		}

		public void AddTrack(Track track, string album)
		{
			if (!this.tracksByAlbumName.ContainsKey(album))
			{
				this.tracksByAlbumName.Add(album, new Dictionary<string, Track>());
			}

			if (!this.tracksByAlbumName[album].ContainsKey(track.Title))
			{
				this.tracksByAlbumName[album].Add(track.Title, track);

				this.tracksById.Add(track.Id, track);
			}
		}

		public bool Contains(Track track) => this.tracksById.ContainsKey(track.Id);

		public int Count => this.tracksById.Count;

		public Track GetTrack(string title, string albumName)
		{
			if (!this.tracksByAlbumName.ContainsKey(albumName)
				|| !this.tracksByAlbumName[albumName].ContainsKey(title))
			{
				throw new ArgumentException();
			}

			return this.tracksByAlbumName[albumName][title];
		}

		public IEnumerable<Track> GetAlbum(string albumName)
		{
			if (!this.tracksByAlbumName.ContainsKey(albumName))
			{
				throw new ArgumentException();
			}

			return this.tracksByAlbumName[albumName].Values
				.OrderByDescending(t => t.Plays);
		}

		public void AddToQueue(string trackName, string albumName)
		{
			if (!this.tracksByAlbumName.ContainsKey(albumName)
				|| !this.tracksByAlbumName[albumName].ContainsKey(trackName))
			{
				throw new ArgumentException();
			}

			this.listeningQueue.Enqueue(this.tracksByAlbumName[albumName][trackName]);
		}

		public Track Play()
		{
			if (this.listeningQueue.Count == 0)
			{
				throw new ArgumentException();
			}

			Track track = this.listeningQueue.Dequeue();

			track.Plays++;

			return track;
		}

		public void RemoveTrack(string trackTitle, string albumName)
		{
			if (!this.tracksByAlbumName.ContainsKey(albumName)
				|| !this.tracksByAlbumName[albumName].ContainsKey(trackTitle))
			{
				throw new ArgumentException();
			}

			Track track = this.tracksByAlbumName[albumName][trackTitle];

			this.tracksByAlbumName[albumName].Remove(trackTitle);

			this.tracksById.Remove(track.Id);

			this.listeningQueue = new Queue<Track>(this.listeningQueue.Where(t => t.Id != track.Id));
		}

		public IEnumerable<Track> GetTracksInDurationRangeOrderedByDurationThenByPlaysDescending(int lowerBound, int upperBound)
			=> this.tracksById.Values
			   .Where(t => t.DurationInSeconds >= lowerBound && t.DurationInSeconds <= upperBound)
			   .OrderBy(t => t.DurationInSeconds)
			   .ThenByDescending(t => t.Plays);

		public IEnumerable<Track> GetTracksOrderedByAlbumNameThenByPlaysDescendingThenByDurationDescending()
		{
			//       List<Track> tracks = new List<Track>(this.Count);

			//       foreach (var kvp in this.tracksByAlbumName)
			//       {
			//           tracks.AddRange(kvp.Value.Values
			//.OrderByDescending(t => t.Plays)
			//.ThenByDescending(t => t.DurationInSeconds));
			//       }

			//       return tracks;

			return this.tracksByAlbumName
				.SelectMany(outerKVP => outerKVP.Value.Values)
				.OrderByDescending(t => t.Plays)
				.ThenByDescending(t => t.DurationInSeconds);
		}

		public Dictionary<string, List<Track>> GetDiscography(string artistName)
		{
			Dictionary<string, List<Track>> discography = new Dictionary<string, List<Track>>();

			foreach (var kvp in this.tracksByAlbumName)
			{
				var tracks = kvp.Value.Values
					.Where(t => t.Artist == artistName)
					.ToList();

				if (tracks.Count > 0)
				{
					discography.Add(kvp.Key, tracks);
				}
			}

			if (discography.Count == 0)
			{
				throw new ArgumentException();
			}

			return discography;
		}
	}
}
