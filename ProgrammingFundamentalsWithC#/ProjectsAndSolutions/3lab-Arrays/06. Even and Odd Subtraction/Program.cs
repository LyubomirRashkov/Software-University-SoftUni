using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int sumOfEvenNumbers = 0;
            int sumOfOddNumbers = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sumOfEvenNumbers += numbers[i];
                }
                else
                {
                    sumOfOddNumbers += numbers[i];
                }
            }

            Console.WriteLine(sumOfEvenNumbers - sumOfOddNumbers);
        }
    }
}
