using System.ComponentModel.DataAnnotations;
using static Library.Constants.DataConstants.Book;

namespace Library.Data.Models
{
    public class Book
    {
        public Book()
        {
            this.ApplicationUsersBooks = new HashSet<ApplicationUserBook>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<ApplicationUserBook> ApplicationUsersBooks { get; set; }
    }
}
