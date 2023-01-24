using System.ComponentModel.DataAnnotations;
using static Library.Constants.DataConstants.Category;

namespace Library.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
