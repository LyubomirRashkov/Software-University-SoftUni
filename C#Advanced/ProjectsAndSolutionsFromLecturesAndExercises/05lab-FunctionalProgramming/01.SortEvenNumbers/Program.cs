using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(num => num % 2 == 0)
                .OrderBy(num => num)
                .ToList();

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
