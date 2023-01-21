using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;
using Watchlist.Services.Interfaces;

namespace Watchlist.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext dbContext;

        public MovieService(WatchlistDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddMovieAsync(MovieImportViewModel model)
        {
            var movie = new Movie()
            {
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                GenreId = model.GenreId,
            };

            await this.dbContext.Movies.AddAsync(movie);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddMovieToUserCollectionAsync(int movieId, string userId)
        {
            var user = await this.GetUserAsync(userId);

            if (user is null)
            {
                throw new ArgumentException("Invalid user Id!");
            }

            var movie = await this.dbContext.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

            if (movie is null)
            {
                throw new ArgumentException("Invalid movie id!");
            }

            if (!user.UsersMovies.Any(um => um.MovieId == movieId))
            {
                var userMovie = new UserMovie()
                {
                    UserId = userId,
                    MovieId = movieId,
                };

                user.UsersMovies.Add(userMovie);

                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<GenreViewModel>> GetAllGenresAsync()
        {
            var genres = await this.dbContext.Genres
                .Select(g => new GenreViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                })
                .ToListAsync();

            return genres;
        }

        public async Task<IEnumerable<MovieExportViewModel>> GetAllMoviesAsync()
        {
            var movies = await this.dbContext.Movies
                .Select(m => new MovieExportViewModel()
                {
                    Id = m.Id,
                    ImageUrl = m.ImageUrl,
                    Title = m.Title,
                    Director = m.Director,
                    Rating = m.Rating,
                    Genre = m.Genre.Name,
                })
                .ToListAsync();

            return movies;
        }

        public async Task<IEnumerable<MovieExportViewModel>> GetUserMoviesAsync(string userId)
        {
            var user = await this.GetUserAsync(userId);

            if (user is null)
            {
                throw new ArgumentException("Invalid user id!");
            }

            var userMovies = user.UsersMovies
                .Select(um => new MovieExportViewModel()
                {
                    Id = um.MovieId,
                    Title = um.Movie.Title,
                    Director = um.Movie.Director,
                    Genre = um.Movie.Genre.Name,
                    Rating = um.Movie.Rating,
                    ImageUrl = um.Movie.ImageUrl,
                })
                .ToList();

            return userMovies;
        }

        public async Task RemoveMovieFromUserCollectionAsync(int movieId, string userId)
        {
            var user = await this.GetUserAsync(userId);

            if (user is null)
            {
                throw new ArgumentException("Invalid user id!");
            }

            var userMovie = user.UsersMovies.FirstOrDefault(um => um.MovieId == movieId);

            if (userMovie is null)
            {
                throw new ArgumentException("Invalid movie id!");
            }

                user.UsersMovies.Remove(userMovie);

                await this.dbContext.SaveChangesAsync();
        }

        private async Task<User> GetUserAsync(string userId)
        {
            var user = await this.dbContext.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(um => um.Movie)
                .ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync();

            return user;
        }
    }
}
