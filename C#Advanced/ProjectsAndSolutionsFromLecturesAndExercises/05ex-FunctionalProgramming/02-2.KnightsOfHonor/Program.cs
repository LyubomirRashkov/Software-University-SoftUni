using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_2.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<List<string>> printCollection = collection => collection.ForEach(x => Console.WriteLine($"Sir {x}"));

            printCollection(names);
        }
    }
}
