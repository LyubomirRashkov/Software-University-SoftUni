using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MovieDatabase
{
    public class MovieDatabase : IMovieDatabase
    {
        private readonly HashSet<Actor> actors = new HashSet<Actor>();

        private readonly HashSet<Movie> movies = new HashSet<Movie>();

        public void AddActor(Actor actor) => actors.Add(actor);

        public void AddMovie(Actor actor, Movie movie)
        {
            if (!this.actors.Contains(actor))
            {
                throw new ArgumentException();
            }

            if (!this.movies.Contains(movie))
            {
                this.movies.Add(movie);
            }

            this.actors.FirstOrDefault(a => a.Id == actor.Id).Movies.Add(movie);
        }

        public bool Contains(Actor actor) => this.actors.Contains(actor);

        public bool Contains(Movie movie) => this.movies.Contains(movie);

        public IEnumerable<Movie> GetAllMovies() => this.movies;

        public IEnumerable<Actor> GetNewbieActors() 
            => this.actors
                .Where(a => a.Movies.Count == 0);

        public IEnumerable<Movie> GetMoviesOrderedByBudgetThenByRating()
            => this.movies
                .OrderByDescending(m => m.Budget)
                .ThenByDescending(m => m.Rating);

        public IEnumerable<Actor> GetActorsOrderedByMaxMovieBudgetThenByMoviesCount()
            => this.actors
                .OrderByDescending(a => a.Movies.Count > 0 ? a.Movies.Max(m => m.Budget) : 0)
                .ThenByDescending(a => a.Movies.Count);

        public IEnumerable<Movie> GetMoviesInRangeOfBudget(double lower, double upper)
            => this.movies
                .Where(m => m.Budget >= lower && m.Budget <= upper)
                .OrderByDescending(m => m.Rating);
    }
}
