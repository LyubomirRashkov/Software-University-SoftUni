using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int number = int.Parse(Console.ReadLine());

            Func<int, int, bool> filter = (num, divider) => num % divider != 0;

            List<int> filteredNumbers = inputNumbers
                .Where(num => filter(num, number))
                .Reverse()
                .ToList();

            Console.WriteLine(string.Join(' ', filteredNumbers));
        }
    }
}
