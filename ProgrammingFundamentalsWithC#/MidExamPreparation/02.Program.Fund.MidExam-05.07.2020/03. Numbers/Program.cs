using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int sumOfElements = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sumOfElements += numbers[i];
            }

            double average = (double)sumOfElements / numbers.Count;

            bool isGreaterFound = false;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= average)
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
                else
                {
                    isGreaterFound = true;
                }
            }

            if (!isGreaterFound)
            {
                Console.WriteLine("No");
            }
            else
            {
                numbers.Sort();
                numbers.Reverse();

                if (numbers.Count > 5)
                {
                    numbers.RemoveRange(5, numbers.Count - 5);

                    Console.WriteLine(string.Join(" ", numbers));
                }
                else
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
            }
        }
    }
}
