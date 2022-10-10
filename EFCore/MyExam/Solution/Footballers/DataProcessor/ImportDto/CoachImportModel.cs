using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class CoachImportModel
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ValidationConstants.CoachNameMinLength)]
        [MaxLength(ValidationConstants.CoachNameMaxLength)]
        public string Name { get; set; }

        [XmlElement("Nationality")]
        [Required]
        public string Nationality { get; set; }

        public FootballerImportModel[] Footballers { get; set; }
    }
}
