using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int smallestNumber = GetSmallestNumber(firstNumber, secondNumber, thirdNumber);

            Console.WriteLine(smallestNumber);
        }

        private static int GetSmallestNumber(int firstNumber, int secondNumber, int thirdNumber)
        {
            int minNumber = int.MaxValue;

            int[] numbers = { firstNumber, secondNumber, thirdNumber };

            for (int i = 0; i < 3; i++)
            {
                if (minNumber > numbers[i])
                {
                    minNumber = numbers[i];
                }
            }

            return minNumber;
        }
    }
}
