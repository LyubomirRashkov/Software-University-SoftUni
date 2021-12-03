using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            long firstFactorial = GetFactorial(firstNumber);
            long secondFactorial = GetFactorial(secondNumber);

            double result = (firstFactorial * 1.0) / secondFactorial;
            Console.WriteLine($"{result:F2}");
        }

        private static long GetFactorial(int number)
        {
            long factorial = 1;

            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
