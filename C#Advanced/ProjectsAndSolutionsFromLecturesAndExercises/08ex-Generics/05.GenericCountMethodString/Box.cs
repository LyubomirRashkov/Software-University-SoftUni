using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodString
{
    public static class Box
    {
        public static int CountOfGreaterElements<T>(List<T> collection, T elementToCompareWith)
            where T : IComparable
        {
            int count = 0;

            foreach (T element in collection)
            {
                if (element.CompareTo(elementToCompareWith) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
