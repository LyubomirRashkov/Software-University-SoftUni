namespace Exam.ViTube
{
    public class Video
    {
        public Video(string id, string title, double length, int views, int likes, int dislikes)
        {
            this.Id = id;
            this.Title = title;
            this.Length = length;
            this.Views = views;
            this.Likes = likes;
            this.Dislikes = dislikes;
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public double Length { get; set; }

        public int Views { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}
