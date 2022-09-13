using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ShellImportModel
    {
        [XmlElement("ShellWeight")]
        [Range(ValidationConstants.ShellShellWeightMinValue, ValidationConstants.ShellShellWeightMaxValue)]
        public double ShellWeight { get; set; }

        [XmlElement("Caliber")]
        [Required]
        [MinLength(ValidationConstants.ShellCaliberMinLengthValue)]
        [MaxLength(ValidationConstants.ShellCaliberMaxLengthValue)]
        public string Caliber { get; set; }
    }
}
