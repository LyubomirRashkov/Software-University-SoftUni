using System.Collections.Generic;

namespace SoftJail.Data.Models
{
    public class Cell
    {
        public Cell()
        {
            this.Prisoners = new HashSet<Prisoner>();
        }

        public int Id { get; set; }

        public int CellNumber { get; set; }

        public bool HasWindow { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Prisoner> Prisoners { get; set; }
    }
}
