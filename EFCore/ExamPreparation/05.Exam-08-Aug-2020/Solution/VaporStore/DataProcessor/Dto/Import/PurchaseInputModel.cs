using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchaseInputModel
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [Required]
        public PurchaseType? Type { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.PurchaseProductKeyRegEx)]
        public string Key { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.CardNumberRegEx)]
        public string Card { get; set; }

        [Required]
        public string Date { get; set; }
    }
}
