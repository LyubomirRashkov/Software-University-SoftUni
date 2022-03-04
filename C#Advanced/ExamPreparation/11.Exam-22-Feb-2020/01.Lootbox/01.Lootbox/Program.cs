using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> first = new Queue<int>(Console.ReadLine()
                                              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                              .Select(int.Parse)
                                              .ToArray());

            Stack<int> second = new Stack<int>(Console.ReadLine()
                                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                               .Select(int.Parse)
                                               .ToArray());

            int sumOfClaimedItems = 0;

            while (first.Count > 0 && second.Count > 0)
            {
                int firstItem = first.Peek();

                int secondItem = second.Pop();

                if ((firstItem + secondItem) % 2 == 0)
                {
                    sumOfClaimedItems += (firstItem + secondItem);

                    first.Dequeue();
                }
                else
                {
                    first.Enqueue(secondItem);
                }
            }

            if (first.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (second.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sumOfClaimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumOfClaimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumOfClaimedItems}");
            }
        }
    }
}
