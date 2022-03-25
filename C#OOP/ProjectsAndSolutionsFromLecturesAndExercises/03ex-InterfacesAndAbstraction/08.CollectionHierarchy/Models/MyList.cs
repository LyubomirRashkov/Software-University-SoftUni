using _08.CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace _08.CollectionHierarchy.Models
{
    public class MyList : IAddable, IRemoveable
    {
        private List<string> collection;

        public MyList()
        {
            this.collection = new List<string>();
        }

        public int Used => this.Collection.Count;

        public IReadOnlyCollection<string> Collection => this.collection.AsReadOnly();

        public int Add(string element)
        {
            this.collection.Insert(0, element);

            return 0;
        }

        public string Remove()
        {
            string element = this.collection[0];

            this.collection.RemoveAt(0);

            return element;
        }
    }
}
