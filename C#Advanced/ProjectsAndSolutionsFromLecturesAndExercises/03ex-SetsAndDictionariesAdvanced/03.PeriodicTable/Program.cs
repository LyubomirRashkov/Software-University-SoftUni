using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputLines = int.Parse(Console.ReadLine());

            SortedSet<string> uniqueElements = new SortedSet<string>();

            for (int i = 0; i < numberOfInputLines; i++)
            {
                string[] lineParts = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (string element in lineParts)
                {
                    uniqueElements.Add(element);
                }
            }

            Console.WriteLine(string.Join(' ', uniqueElements));
        }
    }
}
