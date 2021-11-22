using System;

namespace _06._Multiply_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int firstDigit = number % 10;
            int secondDigit = (number / 10) % 10;
            int thirdDigit = number / 100;

            for (int i = 1; i <= firstDigit; i++)
            {
                for (int j = 1; j <= secondDigit; j++)
                {
                    for (int k = 1; k <= thirdDigit; k++)
                    {
                        Console.WriteLine($"{i} * {j} * {k} = {i * j* k};");
                    }
                }
            }
        }
    }
}
