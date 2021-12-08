using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Go Shopping!")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parts[0] == "Urgent")
                {
                    if (!products.Contains(parts[1]))
                    {
                        products.Insert(0, parts[1]);
                    }
                }
                else if (parts[0] == "Unnecessary")
                {
                    products.Remove(parts[1]);
                }
                else if (parts[0] == "Correct")
                {
                    string oldProduct = parts[1];
                    string newProduct = parts[2];

                    int oldProductIndex = products.IndexOf(oldProduct);

                    if (oldProductIndex != -1)
                    {
                        products.RemoveAt(oldProductIndex);
                        products.Insert(oldProductIndex, newProduct);
                    }
                }
                else if (parts[0] == "Rearrange")
                {
                    if (products.Remove(parts[1]))
                    {
                        string product = parts[1];
                        products.Add(product);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", products));
        }
    }
}
