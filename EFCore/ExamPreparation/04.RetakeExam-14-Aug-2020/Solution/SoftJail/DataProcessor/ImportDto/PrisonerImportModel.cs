using System;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerImportModel
    {
        [Required]
        [MinLength(ValidationConstants.PrisonerFullNameMinLength)]
        [MaxLength(ValidationConstants.PrisonerFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.PrisonerNickNameRegEx)]
        public string Nickname { get; set; }

        [Required]
        [Range(ValidationConstants.PrisonerAgeMinValue, ValidationConstants.PrisonerAgeMaxValue)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        [Range(typeof(decimal), ValidationConstants.PrisonerBailMinValue, ValidationConstants.PrisonerBailMaxValue)]
        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public MailImportModel[] Mails { get; set; }
    }
}
