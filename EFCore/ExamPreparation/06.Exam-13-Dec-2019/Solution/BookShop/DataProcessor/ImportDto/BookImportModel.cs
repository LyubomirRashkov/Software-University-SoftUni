using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class BookImportModel
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ValidationConstants.BookNameMinLength)]
        [MaxLength(ValidationConstants.BookNameMaxLength)]
        public string Name { get; set; }

        [XmlElement("Genre")]
        [Required]
        [Range(ValidationConstants.BookGenreMinValue, ValidationConstants.BookGenreMaxValue)]
        public int Genre { get; set; }

        [XmlElement("Price")]
        [Required]
        [Range(typeof(decimal), ValidationConstants.BookPriceMinValue, ValidationConstants.BookPriceMaxValue)]
        public decimal Price { get; set; }

        [XmlElement("Pages")]
        [Required]
        [Range(ValidationConstants.BookPagesMinValue, ValidationConstants.BookPagesMaxValue)]
        public int Pages { get; set; }

        [XmlElement("PublishedOn")]
        [Required]
        public string PublishedOn { get; set; }
    }
}
