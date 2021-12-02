using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string mathAction = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if (mathAction == "add")
            {
                Add(firstNumber, secondNumber);
            }
            else if (mathAction == "multiply")
            {
                Multiply(firstNumber, secondNumber);
            }
            else if (mathAction == "subtract")
            {
                Subtract(firstNumber, secondNumber);
            }
            else if (mathAction == "divide")
            {
                Divide(firstNumber, secondNumber);
            }
        }

        private static void Divide(int firstNumber, int secondNumber)
        {
            Console.WriteLine((double)firstNumber / secondNumber);
        }

        private static void Subtract(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber - secondNumber);
        }

        private static void Multiply(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber * secondNumber);
        }

        private static void Add(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber + secondNumber);
        }
    }
}
