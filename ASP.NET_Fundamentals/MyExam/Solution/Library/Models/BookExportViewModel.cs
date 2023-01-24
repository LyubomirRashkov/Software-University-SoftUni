namespace Library.Models
{
    public class BookExportViewModel
    {
        public int Id { get; init; }

        public string ImageUrl { get; init; } = null!;

        public string Title { get; init; } = null!;

        public string Author { get; init; } = null!;

        public string Category { get; init; } = null!;
    }
}
