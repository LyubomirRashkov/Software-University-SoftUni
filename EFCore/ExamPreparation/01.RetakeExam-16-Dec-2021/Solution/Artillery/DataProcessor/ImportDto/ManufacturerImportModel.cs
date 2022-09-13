using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ManufacturerImportModel
    {
        [XmlElement("ManufacturerName")]
        [Required]
        [MinLength(ValidationConstants.ManufacturerManufacturerNameMinLengthValue)]
        [MaxLength(ValidationConstants.ManufacturerManufacturerNameMaxLengthValue)]
        public string ManufacturerName { get; set; }

        [XmlElement("Founded")]
        [Required]
        [MinLength(ValidationConstants.ManufacturerFoundedMinLengthValue)]
        [MaxLength(ValidationConstants.ManufacturerFoundedMaxLengthValue)]
        public string Founded { get; set; }
    }
}
