using System;

namespace _01_2._Smallest_of_Three_Numbers
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
            int minNumber = Math.Min(
                Math.Min(firstNumber, secondNumber), thirdNumber);

            return minNumber;
        }
    }
}
