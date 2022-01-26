using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> getSmallestNumber = numbers =>
            {
                int minNumber = int.MaxValue;

                foreach (int number in numbers)
                {
                    if (number < minNumber)
                    {
                        minNumber = number;
                    }
                }

                return minNumber;
            };

            int minNumber = getSmallestNumber(inputNumbers);

            Console.WriteLine(minNumber);
        }
    }
}
