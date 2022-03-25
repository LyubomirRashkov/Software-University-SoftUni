using _08.CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace _08.CollectionHierarchy.Models
{
    public class AddCollection : IAddable
    {
        private List<string> collection;

        public AddCollection()
        {
            this.collection = new List<string>();
        }

        public IReadOnlyCollection<string> Collection => this.collection.AsReadOnly();

        public int Add(string element)
        {
            this.collection.Add(element);

            return this.collection.Count - 1;
        }
    }
}
