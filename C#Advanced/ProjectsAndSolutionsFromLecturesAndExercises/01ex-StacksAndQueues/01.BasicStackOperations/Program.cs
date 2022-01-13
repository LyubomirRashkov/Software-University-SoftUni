using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] specialNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numberOfElementsToPop = specialNumbers[1];
            int elementToLookFor = specialNumbers[2];

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbersInTheStack = new Stack<int>(numbers);

            for (int i = 0; i < numberOfElementsToPop; i++)
            {
                if (numbersInTheStack.Count == 0)
                {
                    break;
                }

                numbersInTheStack.Pop();
            }

            if (numbersInTheStack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if (numbersInTheStack.Contains(elementToLookFor))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int minElement = numbersInTheStack.Min();

                    Console.WriteLine(minElement);
                }
            }
        }
    }
}
