using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Craft!")
                {
                    break;
                }

                string[] parts = line
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                if (parts[0] == "Collect")
                {
                    if (!inventory.Contains(parts[1]))
                    {
                        inventory.Add(parts[1]);
                    }
                }
                else if (parts[0] == "Drop")
                {
                    inventory.Remove(parts[1]);
                }
                else if (parts[0] == "Combine Items")
                {
                    string[] items = parts[1]
                        .Split(":", StringSplitOptions.RemoveEmptyEntries);

                    string oldItem = items[0];
                    string newItem = items[1];

                    int oldItemIndex = inventory.IndexOf(oldItem);

                    if (oldItemIndex != -1)
                    {
                        inventory.Insert(oldItemIndex + 1, newItem);
                    }
                }
                else if (parts[0] == "Renew")
                {
                    if (inventory.Remove(parts[1]))
                    {
                        inventory.Add(parts[1]);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", inventory));
        }
    }
}
