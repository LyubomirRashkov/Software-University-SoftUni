using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            double secondNumber = double.Parse(Console.ReadLine());

            double result = Calculate(firstNumber, @operator, secondNumber);

            Console.WriteLine(Math.Round(result, 2));
        }

        private static double Calculate(double firstNumber, string @operator, double secondNumber)
        {
            double result = 0;

            if (@operator == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (@operator == "-")
            {
                result = firstNumber - secondNumber;
            }
            else if (@operator == "/")
            {
                result = firstNumber / secondNumber;
            }
            else
            {
                result = firstNumber * secondNumber;
            }

            return result;
        }
    }
}
