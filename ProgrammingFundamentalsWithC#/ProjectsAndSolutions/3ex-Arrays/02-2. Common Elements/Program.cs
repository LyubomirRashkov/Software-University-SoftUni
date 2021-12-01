using System;
using System.Linq;

namespace _02_2._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] secondArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] result = secondArray.Intersect(firstArray).ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
