using System.ComponentModel.DataAnnotations;
using static Library.Constants.DataConstants.Book;

namespace Library.Models
{
    public class BookImportViewModel
    {
        public BookImportViewModel()
        {
            this.Categories = new List<CategoryViewModel>();
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), RatingMinValue, RatingMaxValue, ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public int CategoryId { get; set; }
    }
}
