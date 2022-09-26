using System;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class CellImportModel
    {
        [Required]
        [Range(ValidationConstants.CellCellNumberMinValue, ValidationConstants.CellCellNumberMaxValue)]
        public int CellNumber { get; set; }

        [Required]
        public bool HasWindow { get; set; }
    }
}
