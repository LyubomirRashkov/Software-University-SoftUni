using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Yohoho!")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parts[0] == "Loot")
                {
                    List<string> loots = new List<string>(parts.Length - 1);

                    for (int i = 0; i < parts.Length - 1; i++)
                    {
                        loots.Add(parts[i + 1]);
                    }

                    for (int i = 0; i < loots.Count; i++)
                    {
                        bool isContained = false;

                        for (int j = 0; j < chest.Count; j++)
                        {
                            if (loots[i] == chest[j])
                            {
                                isContained = true;
                                break;
                            }
                        }

                        if (!isContained)
                        {
                            chest.Insert(0, loots[i]);
                        }
                    }
                }
                else if (parts[0] == "Drop")
                {
                    int index = int.Parse(parts[1]);

                    if (index >= 0 && index < chest.Count)
                    {
                        string removedItem = chest[index];
                        chest.RemoveAt(index);
                        chest.Add(removedItem);
                    }
                }
                else if (parts[0] == "Steal")
                {
                    int count = int.Parse(parts[1]);

                    if (count > chest.Count)
                    {
                        count = chest.Count;
                    }

                    List<string> stolenItems = new List<string>();

                    int counter = 0;

                    for (int i = chest.Count - count; i < chest.Count; i++)
                    {

                        stolenItems.Add(chest[chest.Count - count + counter]);
                        counter++;
                    }

                    chest.RemoveRange(chest.Count - count, count);

                    Console.WriteLine(string.Join(", ", stolenItems));
                }
            }

            if (chest.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                int sum = 0;

                for (int i = 0; i < chest.Count; i++)
                {
                    sum += chest[i].Length;
                }

                double average = (double)sum / chest.Count;

                Console.WriteLine($"Average treasure gain: {average:F2} pirate credits.");
            }
        }
    }
}
