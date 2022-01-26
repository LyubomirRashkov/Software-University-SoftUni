using System;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boundaries = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lowerBoundary = boundaries[0];
            int upperBoundary = boundaries[1];

            int[] numbers = Enumerable.Range(lowerBoundary, upperBoundary - lowerBoundary + 1).ToArray();

            string filterWord = Console.ReadLine();

            Predicate<int> filter = num => true;

            if (filterWord == "even")
            {
                filter = num => num % 2 == 0;
            }
            else
            {
                filter = num => num % 2 != 0;
            }

            int[] filteredNumbers = numbers
                .Where(num => filter(num))
                .ToArray();

            Console.WriteLine(string.Join(" ", filteredNumbers));
        }
    }
}
