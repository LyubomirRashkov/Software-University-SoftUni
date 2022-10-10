using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    public class TeamImportModel
    {
        [Required]
        [MinLength(ValidationConstants.TeamNameMinLength)]
        [MaxLength(ValidationConstants.TeamNameMaxLength)]
        [RegularExpression(ValidationConstants.TeamNameRegEx)]
        public string Name { get; set; }

        [Required]
        [MinLength(ValidationConstants.TeamNationalityMinLength)]
        [MaxLength(ValidationConstants.TeamNationalityMaxLength)]
        public string Nationality { get; set; }

        [Required]
        public string Trophies { get; set; }

        public HashSet<int> Footballers { get; set; }
    }
}
