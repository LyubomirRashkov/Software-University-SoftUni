using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    public class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            const int startingIndex = 0;

            int sumOfNumbers = SumArray(numbers, startingIndex);

            Console.WriteLine(sumOfNumbers);
        }

        private static int SumArray(int[] array, int startingIndex)
        {
            if (startingIndex == array.Length)
            {
                return 0;
            }

            return array[startingIndex] + SumArray(array, startingIndex + 1);
        }
    }
}
