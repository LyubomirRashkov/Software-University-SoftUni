using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryItems = new Dictionary<string, int>()
            {
                {"shards", 0},
                {"fragments", 0},
                {"motes", 0}
            };

            SortedDictionary<string, int> junkItems = new SortedDictionary<string, int>();

            bool arenot250Found = true;

            string specialItem = string.Empty;

            while (arenot250Found)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < line.Length; i += 2)
                {
                    int quantity = int.Parse(line[i]);
                    string item = line[i + 1].ToLower();

                    if (legendaryItems.ContainsKey(item))
                    {
                        legendaryItems[item] += quantity;

                        if (legendaryItems[item] >= 250)
                        {
                            specialItem = item;
                            legendaryItems[item] -= 250;
                            arenot250Found = false;
                            break;
                        }
                    }
                    else
                    {
                        if (junkItems.ContainsKey(item))
                        {
                            junkItems[item] += quantity;
                        }
                        else
                        {
                            junkItems.Add(item, quantity);
                        }
                    }
                }
            }

            Dictionary<string, int> sortedLegendaryItems = legendaryItems
                .OrderByDescending(i => i.Value)
                .ThenBy(i => i.Key)
                .ToDictionary(i => i.Key, i => i.Value);

            if (specialItem == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (specialItem == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else if (specialItem == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
            }

            foreach (var kvp in sortedLegendaryItems)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkItems)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
