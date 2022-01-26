using System;
using System.Linq;

namespace _05_2.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(double.Parse)
              .ToArray();

            Func<double[], double[]> addition = collection => collection.Select(el => el + 1).ToArray();
            Func<double[], double[]> multiplication = collection => collection.Select(el => el * 2).ToArray();
            Func<double[], double[]> subtraction = collection => collection.Select(el => el - 1).ToArray();
            Action<double[]> print = collection => Console.WriteLine(string.Join(' ', collection));

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (command == "add")
                {
                    numbers = addition(numbers);
                }
                else if (command == "multiply")
                {
                    numbers = multiplication(numbers);
                }
                else if (command == "subtract")
                {
                    numbers = subtraction(numbers);
                }
                else if (command == "print")
                {
                    print(numbers);
                }
            }
        }
    }
}
