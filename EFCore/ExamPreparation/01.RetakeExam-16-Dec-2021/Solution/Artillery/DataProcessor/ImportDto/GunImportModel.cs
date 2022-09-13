using Artillery.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Artillery.DataProcessor.ImportDto
{
    public class GunImportModel
    {
        public int ManufacturerId { get; set; }

        [Range(ValidationConstants.GunGunWeightMinValue, ValidationConstants.GunGunWeightMaxValue)]
        public int GunWeight { get; set; }

        [Range(ValidationConstants.GunBarrelLengthMinValue, ValidationConstants.GunBarrelLengthMaxValue)]
        public double BarrelLength { get; set; }
        
        public int? NumberBuild { get; set; }

        [Range(ValidationConstants.GunRangeMinValue, ValidationConstants.GunRangeMaxValue)]
        public int Range { get; set; }

        [Required]
        public string GunType { get; set; }
        
        public int ShellId { get; set; }
        
        public CountryGunImportModel[] Countries { get; set; }
    }
}
