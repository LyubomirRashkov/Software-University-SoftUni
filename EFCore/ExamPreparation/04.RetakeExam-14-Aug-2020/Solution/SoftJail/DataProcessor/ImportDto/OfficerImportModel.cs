using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerImportModel
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ValidationConstants.OfficerFullNameMinLength)]
        [MaxLength(ValidationConstants.OfficerFullNameMaxLength)]
        public string Name { get; set; }

        [XmlElement("Money")]
        [Required]
        [Range(typeof(decimal), ValidationConstants.OfficerSalaryMinValue, ValidationConstants.OfficerSalaryMaxValue)]
        public decimal Money { get; set; }

        [XmlElement("Position")]
        [Required]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        [Required]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        [Required]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public OfficerPrisonerImportModel[] Prisoners { get; set; }
    }
}
