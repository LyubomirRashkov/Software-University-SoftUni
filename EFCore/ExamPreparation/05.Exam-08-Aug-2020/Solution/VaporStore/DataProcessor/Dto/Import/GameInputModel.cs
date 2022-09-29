using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class GameInputModel
    {
        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal), GlobalConstants.GamePriceMinValue, GlobalConstants.GamePriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        public  IEnumerable<string> Tags { get; set; }
    }
}
