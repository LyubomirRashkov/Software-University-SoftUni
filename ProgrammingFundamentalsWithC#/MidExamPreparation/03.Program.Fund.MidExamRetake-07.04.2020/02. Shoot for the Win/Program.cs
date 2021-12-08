using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int shotTargetsCount = 0;

            List<int> shotTargetsIndexes = new List<int>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                int index = int.Parse(line);

                if (index < 0 || index >= targets.Length)
                {
                    continue;
                }

                if (!shotTargetsIndexes.Contains(index))
                {
                    int shotTarget = targets[index];

                    shotTargetsIndexes.Add(index);

                    shotTargetsCount++;

                    targets[index] = -1;

                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (i == index || shotTargetsIndexes.Contains(i))
                        {
                            continue;
                        }

                        int currentTarget = targets[i];

                        if (currentTarget > shotTarget)
                        {
                            targets[i] -= shotTarget;
                        }
                        else
                        {
                            targets[i] += shotTarget;
                        }
                    }
                }
            }

            Console.Write($"Shot targets: {shotTargetsCount} -> ");
            Console.WriteLine(string.Join(" ", targets));
        }
    }
}
