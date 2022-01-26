using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Func<double, double> addition = num => num + 1;
            Func<double, double> multiplication = num => num * 2;
            Func<double, double> subtraction = num => num - 1;
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
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = addition(numbers[i]);
                    }
                }
                else if (command == "multiply")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = multiplication(numbers[i]);
                    }
                }
                else if (command == "subtract")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = subtraction(numbers[i]);
                    }
                }
                else if (command == "print")
                {
                    print(numbers);
                }
            }
        }
    }
}
