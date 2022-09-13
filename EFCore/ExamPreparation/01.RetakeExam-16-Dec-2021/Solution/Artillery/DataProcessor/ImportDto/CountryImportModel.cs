using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class CountryImportModel
    {
        [XmlElement("CountryName")]
        [Required]
        [MaxLength(ValidationConstants.CountryCountryNameMaxLengthValue)]
        [MinLength(ValidationConstants.CountryCountryNameMinLengthValue)]
        public string CountryName { get; set; }

        [XmlElement("ArmySize")]
        [Range(ValidationConstants.CountryArmySizeMinValue, ValidationConstants.CountryArmySizeMaxValue)]
        public int ArmySize { get; set; }
    }
}
