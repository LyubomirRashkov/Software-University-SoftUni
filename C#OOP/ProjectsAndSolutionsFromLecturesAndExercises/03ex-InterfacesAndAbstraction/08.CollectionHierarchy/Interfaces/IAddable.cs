using System.Collections.Generic;

namespace _08.CollectionHierarchy.Interfaces
{
    public interface IAddable
    {
        IReadOnlyCollection<string> Collection { get; }

        int Add(string element);
    }
}
