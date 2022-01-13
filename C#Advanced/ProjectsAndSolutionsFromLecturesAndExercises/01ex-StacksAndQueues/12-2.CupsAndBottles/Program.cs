using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_2.CupsAndBottles
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

            int currentCup = 0;

            bool isANewCupRequired = true;

            while (queueOfCups.Count > 0 && stackOfBottles.Count > 0)
            {
                if (isANewCupRequired)
                {
                    currentCup = queueOfCups.Peek();
                }

                int currentBottle = stackOfBottles.Pop();

                if (currentBottle >= currentCup)
                {
                    queueOfCups.Dequeue();
                    wastedLittres += (currentBottle - currentCup);
                    isANewCupRequired = true;
                }
                else
                {
                    currentCup -= currentBottle;

                    isANewCupRequired = false;
                }
            }

            if (stackOfBottles.Any())
            {
                Console.Write("Bottles: ");

                Console.WriteLine(string.Join(" ", stackOfBottles));
            }
            else
            {
                Console.Write("Cups: ");

                Console.WriteLine(string.Join(" ", queueOfCups));
            }

            Console.WriteLine($"Wasted litters of water: {wastedLittres}");
        }
    }
}
