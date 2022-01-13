using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] specialNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numberOfElementsToDequeue = specialNumbers[1];
            int elementToLookFor = specialNumbers[2];

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbersInTheQueue = new Queue<int>(numbers);

            for (int i = 0; i < numberOfElementsToDequeue; i++)
            {
                if (numbersInTheQueue.Count == 0)
                {
                    break;
                }

                numbersInTheQueue.Dequeue();
            }

            if (numbersInTheQueue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if (numbersInTheQueue.Contains(elementToLookFor))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbersInTheQueue.Min());
                }
            }
        }
    }
}
