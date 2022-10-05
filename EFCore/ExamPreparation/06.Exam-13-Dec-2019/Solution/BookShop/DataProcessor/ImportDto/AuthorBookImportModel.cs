using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorBookImportModel
    {
        [Required]
        public int? Id { get; set; }
    }
}
