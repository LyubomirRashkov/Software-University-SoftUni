using Watchlist.Models;

namespace Watchlist.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieExportViewModel>> GetAllMoviesAsync();

        Task<IEnumerable<GenreViewModel>> GetAllGenresAsync();

        Task AddMovieAsync(MovieImportViewModel model);

        Task AddMovieToUserCollectionAsync(int movieId, string userId);

        Task<IEnumerable<MovieExportViewModel>> GetUserMoviesAsync(string userId);

        Task RemoveMovieFromUserCollectionAsync(int movieId, string userId);
    }
}
