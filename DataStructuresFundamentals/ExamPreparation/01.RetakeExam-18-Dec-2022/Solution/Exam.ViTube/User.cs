using System.Collections.Generic;

namespace Exam.ViTube
{
    public class User
    {
        public User(string id, string username)
        {
            this.Id = id;
            this.Username = username;
            this.CountOfWatchedVideos = 0;

            this.LikedVideos = new List<Video>();
            this.DislikedVideos = new List<Video>();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public int CountOfWatchedVideos { get; set; }

        public List<Video> LikedVideos { get; set; }

        public List<Video> DislikedVideos { get; set; }

        public int CountOfVotedVideos => this.LikedVideos.Count + this.DislikedVideos.Count;
    }
}
