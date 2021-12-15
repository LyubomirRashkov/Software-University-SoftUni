using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> appearancesCount = new SortedDictionary<double, int>();

            foreach (int number in numbers)
            {
                if (appearancesCount.ContainsKey(number))
                {
                    appearancesCount[number]++;
                }
                else
                {
                    appearancesCount.Add(number, 1);
                }
            }

            foreach (var kvp in appearancesCount)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
