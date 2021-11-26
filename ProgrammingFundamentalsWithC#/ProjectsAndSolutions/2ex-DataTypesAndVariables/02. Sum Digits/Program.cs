using System;

namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            int sumOfDigits = 0;

            while (inputNumber > 0)
            {
                sumOfDigits += inputNumber % 10;
                inputNumber /= 10;
            }

            Console.WriteLine(sumOfDigits);
        }
    }
}
