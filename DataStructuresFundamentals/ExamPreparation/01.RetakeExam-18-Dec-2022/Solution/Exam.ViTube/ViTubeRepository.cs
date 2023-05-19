using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.ViTube
{
	public class ViTubeRepository : IViTubeRepository
	{
		private readonly Dictionary<string, User> usersById = new Dictionary<string, User>();

		private readonly Dictionary<string, Video> videosById = new Dictionary<string, Video>();

		public void RegisterUser(User user)
		{
			if (!this.usersById.ContainsKey(user.Id))
			{
				this.usersById.Add(user.Id, user);
			}
		}

		public void PostVideo(Video video)
		{
			if (!this.videosById.ContainsKey(video.Id))
			{
				this.videosById.Add(video.Id, video);
			}
		}

		public bool Contains(User user) => this.usersById.ContainsKey(user.Id);

		public bool Contains(Video video) => this.videosById.ContainsKey(video.Id);

		public IEnumerable<Video> GetVideos() => this.videosById.Values;

		public void WatchVideo(User user, Video video)
		{
			this.ValidateUserAndVideo(user, video);

			this.usersById[user.Id].CountOfWatchedVideos++;

			this.videosById[video.Id].Views++;
		}

		public void LikeVideo(User user, Video video)
		{
			this.ValidateUserAndVideo(user, video);

			this.videosById[video.Id].Likes++;

			this.usersById[user.Id].LikedVideos.Add(video);

			if (this.usersById[user.Id].DislikedVideos.Remove(video))
			{
				this.videosById[video.Id].Dislikes--;
			}
		}

		public void DislikeVideo(User user, Video video)
		{
			this.ValidateUserAndVideo(user, video);

			this.videosById[video.Id].Dislikes++;

			this.usersById[user.Id].DislikedVideos.Add(video);

			if (this.usersById[user.Id].LikedVideos.Remove(video))
			{
				this.videosById[video.Id].Likes--;
			}
		}

		public IEnumerable<User> GetPassiveUsers()
			=> this.usersById.Values
				.Where(u => u.CountOfWatchedVideos == 0 
							&& u.LikedVideos.Count == 0 
							&& u.DislikedVideos.Count == 0);

		public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes()
			=> this.videosById.Values
				.OrderByDescending(v => v.Views)
				.ThenByDescending(v => v.Likes)
				.ThenBy(v => v.Dislikes);

		public IEnumerable<User> GetUsersByActivityThenByName()
			=> this.usersById.Values
				.OrderByDescending(u => u.CountOfWatchedVideos)
				.ThenByDescending(u => u.CountOfVotedVideos)
				.ThenBy(u => u.Username);

		private void ValidateUserAndVideo(User user, Video video)
		{
			if (!this.usersById.ContainsKey(user.Id)
				|| !this.videosById.ContainsKey(video.Id))
			{
				throw new ArgumentException();
			}
		}
	}
}
