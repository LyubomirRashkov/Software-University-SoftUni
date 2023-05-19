using System.Collections.Generic;

namespace Exam.MovieDatabase
{
    public class Movie
    {
        public Movie(string id, int durationInMinutes, string title, double rating, double budget)
        {
            this.Id = id;
            this.DurationInMinutes = durationInMinutes;
            this.Title = title;
            this.Rating = rating;
            this.Budget = budget;

            this.Actors = new List<Actor>();
        }

        public string Id { get; set; }

        public int DurationInMinutes { get; set; }

        public string Title { get; set; }

        public double Rating { get; set; }

        public double Budget { get; set; }

        public List<Actor> Actors { get; set; }
    }
}
