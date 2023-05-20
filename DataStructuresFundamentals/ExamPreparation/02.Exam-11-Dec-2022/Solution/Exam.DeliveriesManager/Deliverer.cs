using System.Collections.Generic;

namespace Exam.DeliveriesManager
{
    public class Deliverer
    {
        public Deliverer(string id, string name)
        {
            this.Id = id;
            this.Name = name;

            this.Packages = new List<Package>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public List<Package> Packages { get; set; }
    }
}
