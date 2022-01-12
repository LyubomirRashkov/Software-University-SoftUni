using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elementsOfTheExpression = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Stack<string> elements = new Stack<string>(elementsOfTheExpression.Length);

            for (int i = elementsOfTheExpression.Length - 1; i >= 0; i--)
            {
                elements.Push(elementsOfTheExpression[i]);
            }

            int result = int.Parse(elements.Pop());

            while (elements.Count > 0)
            {
                string action = elements.Pop();

                int element = int.Parse(elements.Pop());

                if (action == "+")
                {
                    result += element;
                }
                else
                {
                    result -= element;
                }
            }

            Console.WriteLine(result);
        }
    }
}
