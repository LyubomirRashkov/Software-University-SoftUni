using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_2.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(double.Parse)
              .ToArray();

            Dictionary<double, int> numbers = new Dictionary<double, int>();

            foreach (double number in input)
            {
                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 0);
                }

                numbers[number]++;
            }

            foreach (var kvp in numbers)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
