using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbersInQueue = new Queue<int>(numbers.Length);

            for (int i = 0; i < numbers.Length; i++)
            {
                numbersInQueue.Enqueue(numbers[i]);
            }

            Queue<int> evenNumbers = new Queue<int>();

            while (numbersInQueue.Count > 0)
            {
                int currentNumber = numbersInQueue.Dequeue();

                if (currentNumber % 2 == 0)
                {
                    evenNumbers.Enqueue(currentNumber);
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
