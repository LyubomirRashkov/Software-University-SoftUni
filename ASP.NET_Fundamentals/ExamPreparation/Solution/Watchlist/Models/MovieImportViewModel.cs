using System.ComponentModel.DataAnnotations;
using static Watchlist.Constants.DataConstants.Movie;

namespace Watchlist.Models
{
    public class MovieImportViewModel
    {
        public MovieImportViewModel()
        {
            this.Genres = new List<GenreViewModel>();
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DirectorMaxLength, MinimumLength = DirectorMinLength)]
        public string Director { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal), RatingMinValue, RatingMaxValue, ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }

        public int GenreId { get; set; }
    }
}
