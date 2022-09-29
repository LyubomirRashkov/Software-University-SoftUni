using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class CardInputModel
    {
        [Required]
        [RegularExpression(GlobalConstants.CardNumberRegEx)]
        public string Number { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.CardCVCRegEx)]
        public string CVC { get; set; }

        [Required]
        public CardType? Type { get; set; }
    }
}

