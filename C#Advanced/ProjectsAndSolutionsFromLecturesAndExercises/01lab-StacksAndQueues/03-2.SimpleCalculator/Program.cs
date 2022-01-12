using System;
using System.Collections.Generic;

namespace _03_2.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elementsOfTheExpression = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Stack<string> elements = new Stack<string>(elementsOfTheExpression.Length);

            for (int i = 0; i < elementsOfTheExpression.Length; i++)
            {
                elements.Push(elementsOfTheExpression[i]);
            }

            Stack<string> reversedElements = new Stack<string>(elements.Count);

            while (elements.Count > 0)
            {
                reversedElements.Push(elements.Pop());
            }

            int result = int.Parse(reversedElements.Pop());

            while (reversedElements.Count > 0)
            {
                string action = reversedElements.Pop();

                int element = int.Parse(reversedElements.Pop());

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
