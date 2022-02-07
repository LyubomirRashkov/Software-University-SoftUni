using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.GenericCountMethodDouble
{
    public static class Box
    {
        public static int CountOfGreaterElements<T>(List<T> collection, T elementToCompareWith)
            where T : IComparable
        {
            int count = collection
                .Where(el => el.CompareTo(elementToCompareWith) > 0)
                .Count();

            return count;
        }
    }
}
