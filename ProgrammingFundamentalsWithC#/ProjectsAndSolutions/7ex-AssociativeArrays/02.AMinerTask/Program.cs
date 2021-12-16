using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> quantityByResource = new Dictionary<string, long>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "stop")
                {
                    break;
                }

                string resource = line;
                long quantity = long.Parse(Console.ReadLine());

                if (quantityByResource.ContainsKey(resource))
                {
                    quantityByResource[resource] += quantity;
                }
                else
                {
                    quantityByResource.Add(resource, quantity);
                }
            }

            foreach (var kvp in quantityByResource)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
