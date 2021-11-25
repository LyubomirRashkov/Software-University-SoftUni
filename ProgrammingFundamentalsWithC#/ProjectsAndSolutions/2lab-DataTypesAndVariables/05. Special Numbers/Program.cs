using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number ; i++)
            {
                int currentNumber = i;
                int sumOfDigits = 0;
                bool isSpecial = false;

                while (currentNumber > 0)
                {
                    int digit = currentNumber % 10;
                    sumOfDigits += digit;
                    currentNumber /= 10;
                }

                if (sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11)
                {
                    isSpecial = true;
                }

                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}
