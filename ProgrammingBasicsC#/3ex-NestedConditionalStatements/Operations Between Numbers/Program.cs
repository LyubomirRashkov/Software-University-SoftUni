using System;

namespace Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            double result = 0;
            string explanation = "";

            switch (operation)
            {
                case '+':
                    result = number1 + number2;
                    if (result % 2 == 0)
                    {
                        explanation = "even";
                    }
                    else
                    {
                        explanation = "odd";
                    }
                    Console.WriteLine($"{number1} {operation} {number2} = {result} - {explanation}");
                    break;
                case '-':
                    result = number1 - number2;
                    if (result % 2 == 0)
                    {
                        explanation = "even";
                    }
                    else
                    {
                        explanation = "odd";
                    }
                    Console.WriteLine($"{number1} {operation} {number2} = {result} - {explanation}");
                    break;
                case '*':
                    result = number1 * number2;
                    if (result % 2 == 0)
                    {
                        explanation = "even";
                    }
                    else
                    {
                        explanation = "odd";
                    }
                    Console.WriteLine($"{number1} {operation} {number2} = {result} - {explanation}");
                    break;
                case '/':
                    if (number2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {number1} by zero");
                    }
                    else
                    {
                        result = number1 / number2;
                        Console.WriteLine($"{number1} {operation} {number2} = {result:f2}");
                    }
                    break;
                case '%':
                    if (number2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {number1} by zero");
                    }
                    else
                    {
                        result = number1 % number2;
                        Console.WriteLine($"{number1} {operation} {number2} = {result}");
                    }
                    break;
            }
        }
    }
} 
