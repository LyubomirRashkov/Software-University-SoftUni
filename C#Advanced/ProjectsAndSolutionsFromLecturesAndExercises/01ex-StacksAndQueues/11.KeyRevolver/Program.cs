using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfOneBullet = int.Parse(Console.ReadLine());

            int sizeOfTheGunBarrel = int.Parse(Console.ReadLine());

            int[] bullets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] locks = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int valueOfTheIntelligence = int.Parse(Console.ReadLine());

            Stack<int> stackOfBullets = new Stack<int>(bullets);

            Queue<int> queueOfLocks = new Queue<int>(locks);

            int countOfUsedBullets = 0;

            while (stackOfBullets.Count > 0 && queueOfLocks.Count > 0)
            {
                int currentBullet = stackOfBullets.Pop();

                countOfUsedBullets++;

                int currentLock = queueOfLocks.Peek();

                if (currentBullet <= currentLock)
                {
                    queueOfLocks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (countOfUsedBullets % sizeOfTheGunBarrel == 0 && stackOfBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }

                if (queueOfLocks.Count == 0)
                {
                    int moneyEarned = valueOfTheIntelligence - (countOfUsedBullets * priceOfOneBullet);

                    Console.WriteLine($"{stackOfBullets.Count} bullets left. Earned ${moneyEarned}");
                }
                else if (stackOfBullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {queueOfLocks.Count}");
                }
            }
        }
    }
}