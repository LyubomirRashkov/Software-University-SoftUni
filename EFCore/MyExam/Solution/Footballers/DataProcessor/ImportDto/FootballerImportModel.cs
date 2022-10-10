using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class FootballerImportModel
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ValidationConstants.FootballerNameMinLength)]
        [MaxLength(ValidationConstants.FootballerNameMaxLength)]
        public string Name { get; set; }

        [XmlElement("ContractStartDate")]
        [Required]
        public string ContractStartDate { get; set; }

        [XmlElement("ContractEndDate")]
        [Required]
        public string ContractEndDate { get; set; }

        [XmlElement("BestSkillType")]
        [Required]
        [Range(0, 4)]
        public int BestSkillType { get; set; }

        [XmlElement("PositionType")]
        [Required]
        [Range(0, 3)]
        public int PositionType { get; set; }
    }
}
