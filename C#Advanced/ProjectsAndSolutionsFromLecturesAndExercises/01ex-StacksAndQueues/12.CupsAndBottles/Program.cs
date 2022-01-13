using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bottles = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOfCups = new Queue<int>(cups);

            Stack<int> stackOfBottles = new Stack<int>(bottles);

            int wastedLittres = 0;

            while (queueOfCups.Count > 0 && stackOfBottles.Count > 0)
            {
                int currentBottle = stackOfBottles.Pop();

                int currentCup = queueOfCups.Peek();

                if (currentBottle >= currentCup)
                {
                    queueOfCups.Dequeue();
                    wastedLittres += (currentBottle - currentCup);
                }
                else
                {
                    currentCup -= currentBottle;

                    while (currentCup > 0)
                    {
                        if (stackOfBottles.Count == 0)
                        {
                            break;
                        }

                        currentBottle = stackOfBottles.Pop();

                        currentCup -= currentBottle;
                    }

                    queueOfCups.Dequeue();

                    wastedLittres += Math.Abs(currentCup);
                }

                if (queueOfCups.Count == 0)
                {
                    Console.Write("Bottles: ");

                    while (stackOfBottles.Count > 0)
                    {
                        Console.Write($"{stackOfBottles.Pop()} ");
                    }

                    Console.WriteLine();
                }
                else if (stackOfBottles.Count == 0)
                {
                    Console.Write("Cups: ");

                    Console.WriteLine(string.Join(" ", queueOfCups));
                }
            }

            Console.WriteLine($"Wasted litters of water: {wastedLittres}");
        }
    }
}
