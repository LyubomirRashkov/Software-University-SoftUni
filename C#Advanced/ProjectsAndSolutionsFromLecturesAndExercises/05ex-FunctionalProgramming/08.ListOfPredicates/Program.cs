using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());

            int[] numbers = Enumerable.Range(1, endOfRange).ToArray();

            int[] specialNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .Select(int.Parse)
                .ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (int number in specialNumbers)
            {
                predicates.Add(num => num % number == 0);
            }

            foreach (Predicate<int> predicate in predicates)
            {
                numbers = numbers
                    .Where(num => predicate(num))
                    .ToArray();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
