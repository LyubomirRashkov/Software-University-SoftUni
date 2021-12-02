using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            int sumOfEvenDigits = GetSumOfEvenDigits(number);
            int sumOfOddDigits = GetSumOfOddDigits(number);

            int result = GetMultipleOfEvenAndOdds(sumOfEvenDigits, sumOfOddDigits);

            Console.WriteLine(result);
        }

        private static int GetMultipleOfEvenAndOdds(int sumOfEvenDigits, int sumOfOddDigits)
        {
            int result = sumOfEvenDigits * sumOfOddDigits;

            return result;
        }

        private static int GetSumOfOddDigits(int number)
        {
            int sumOfOddDigits = 0;

            while (number > 0)
            {
                if ((number % 10) % 2 == 1)
                {
                    sumOfOddDigits += (number % 10);
                }

                number /= 10;
            }

            return sumOfOddDigits;
        }

        private static int GetSumOfEvenDigits(int number)
        {
            int sumOfEvenDigits = 0;

            while (number > 0)
            {
                if ((number % 10) % 2 == 0)
                {
                    sumOfEvenDigits += (number % 10);
                }

                number /= 10;
            }

            return sumOfEvenDigits;
        }
    }
}
