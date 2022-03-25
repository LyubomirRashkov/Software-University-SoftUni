using System.Collections.Generic;

namespace _08.CollectionHierarchy.Interfaces
{
    public interface IRemoveable
    {
        IReadOnlyCollection<string> Collection { get; }

        string Remove();
    }
}
