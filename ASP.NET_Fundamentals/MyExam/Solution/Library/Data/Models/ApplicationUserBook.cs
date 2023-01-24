namespace Library.Data.Models
{
    public class ApplicationUserBook
    {
        public string ApplicationUserId { get; set; } = null!;

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        public int BookId { get; set; }

        public virtual Book Book { get; set; } = null!; 
    }
}
