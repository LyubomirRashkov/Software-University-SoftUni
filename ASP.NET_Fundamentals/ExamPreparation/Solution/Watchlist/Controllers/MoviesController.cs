using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watchlist.Models;
using Watchlist.Services.Interfaces;

namespace Watchlist.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var movies = await this.movieService.GetAllMoviesAsync();

            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new MovieImportViewModel()
            {
                Genres = await this.movieService.GetAllGenresAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieImportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await this.movieService.AddMovieAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong...");

                return View(model);
            }
        }

        public async Task<IActionResult> AddToCollection(int movieId)
        {
            try
            {
                var userId = this.GetUserId();

                await this.movieService.AddMovieToUserCollectionAsync(movieId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            var userId = this.GetUserId();

            var userMovies = await this.movieService.GetUserMoviesAsync(userId);

            return View(userMovies);
        }

        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            string userId = this.GetUserId();

            await this.movieService.RemoveMovieFromUserCollectionAsync(movieId, userId);

            return RedirectToAction(nameof(Watched));
        }

        private string GetUserId() => this.User.Claims
                                          .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";
    }
}
