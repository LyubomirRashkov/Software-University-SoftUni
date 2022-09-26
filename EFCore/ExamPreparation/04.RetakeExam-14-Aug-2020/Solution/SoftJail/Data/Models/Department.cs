using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class Department
    {
        public Department()
        {
            this.Cells = new HashSet<Cell>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.DepartmentNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Cell> Cells { get; set; }
    }
}
