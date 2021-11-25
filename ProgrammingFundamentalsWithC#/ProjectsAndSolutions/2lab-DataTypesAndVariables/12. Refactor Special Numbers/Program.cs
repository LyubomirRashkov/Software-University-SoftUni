using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int finalNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= finalNumber; i++)
            {
                int currentNumber = i;
                int sumOfDigits = 0;

                while (currentNumber > 0)
                {
                    sumOfDigits += currentNumber % 10;
                    currentNumber = currentNumber / 10;
                }

                bool isSpecialNumber = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);

                Console.WriteLine("{0} -> {1}", i, isSpecialNumber);
            }
        }
    }
}
