using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elementsOfTheExpression = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] reversedElementsOfTheExpression = elementsOfTheExpression.Reverse().ToArray();

            Stack<string> elements = new Stack<string>(reversedElementsOfTheExpression.Length);

            for (int i = 0; i < reversedElementsOfTheExpression.Length; i++)
            {
                elements.Push(reversedElementsOfTheExpression[i]);
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
