using _08.CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace _08.CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddable, IRemoveable
    {
        private List<string> collection;

        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }

        public IReadOnlyCollection<string> Collection => this.collection.AsReadOnly();

        public int Add(string element)
        {
            this.collection.Insert(0, element);

            return 0;
        }

        public string Remove()
        {
            string element = this.collection[this.collection.Count - 1];

            this.collection.RemoveAt(this.collection.Count - 1);

            return element;
        }
    }
}
