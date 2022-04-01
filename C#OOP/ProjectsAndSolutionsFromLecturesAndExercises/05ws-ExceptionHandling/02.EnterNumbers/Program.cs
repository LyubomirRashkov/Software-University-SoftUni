using System;
using System.Collections.Generic;

namespace _02.EnterNumbers
{
    public class Program
    {
        static void Main()
        {
            const int TargetCountOfNumbers = 10;
            const int end = 100;

            int start = 1;

            List<int> numbers = new List<int>();

            while (numbers.Count < TargetCountOfNumbers)
            {
                string input = Console.ReadLine();

                try
                {
                    ReadNumber(start, end, input);

                    start = int.Parse(input);

                    numbers.Add(start);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void ReadNumber(int start, int end, string input)
        {
            bool isInteger = int.TryParse(input, out int result);

            if (!isInteger)
            {
                throw new ArgumentException("Invalid Number!");
            }

            if (result <= start || result >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - {end}!");
            }
        }
    }
}
