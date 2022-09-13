using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Guns = new HashSet<Gun>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ManufacturerManufacturerNameMaxLengthValue)]
        public string ManufacturerName { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ManufacturerFoundedMaxLengthValue)]
        public string Founded { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }
    }
}
