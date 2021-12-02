using System;

namespace _01._Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string sign = GetTheSign(number);

            Console.WriteLine($"The number {number} is {sign}.");
        }

        private static string GetTheSign(int number)
        {
            string sign = string.Empty;

            if (number < 0)
            {
                sign = "negative";
            }
            else if (number == 0)
            {
                sign = "zero";
            }
            else
            {
                sign = "positive";
            }

            return sign;
        }
    }
}
