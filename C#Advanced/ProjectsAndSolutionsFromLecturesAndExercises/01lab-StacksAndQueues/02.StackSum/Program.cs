using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbersInStack = new Stack<int>(numbers);

            while (true)
            {
                string line = Console.ReadLine().ToLower();

                if (line == "end")
                {
                    break;
                }

                string[] commandParts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = commandParts[0];

                if (command == "add")
                {
                    int firstNumber = int.Parse(commandParts[1]);
                    int secondNumber = int.Parse(commandParts[2]);

                    numbersInStack.Push(firstNumber);
                    numbersInStack.Push(secondNumber);
                }
                else if (command == "remove")
                {
                    int countOfNumbersToRemove = int.Parse(commandParts[1]);

                    if (countOfNumbersToRemove <= numbersInStack.Count)
                    {
                        for (int i = 0; i < countOfNumbersToRemove; i++)
                        {
                            numbersInStack.Pop();
                        }
                    }
                }
            }

            int sum = numbersInStack.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
