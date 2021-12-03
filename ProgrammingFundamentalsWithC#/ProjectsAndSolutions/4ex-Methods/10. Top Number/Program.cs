using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int sumOfDigits = CalculateSumOfDigits(i);
                bool containsOddDigits = DoesContainOddDigits(i, 1);

                if (sumOfDigits % 8 == 0 && containsOddDigits)
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool DoesContainOddDigits(int number, int targetDigitsCount)
        {
            while (number > 0)
            {
                if ((number % 10) % 2 == 1)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }

        private static int CalculateSumOfDigits(int number)
        {
            int sumOfDigits = 0;

            while (number > 0)
            {
                sumOfDigits += (number % 10);
                number /= 10;
            }

            return sumOfDigits;
        }
    }
}
