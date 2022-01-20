using System;
using System.Collections.Generic;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> productsWithPricesBySupermarkets = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Revision")
                {
                    break;
                }

                string[] lineParts = line.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string supermarket = lineParts[0];
                string product = lineParts[1];
                double price = double.Parse(lineParts[2]);

                if (!productsWithPricesBySupermarkets.ContainsKey(supermarket))
                {
                    productsWithPricesBySupermarkets.Add(supermarket, new Dictionary<string, double>());
                }

                if (!productsWithPricesBySupermarkets[supermarket].ContainsKey(product))
                {
                    productsWithPricesBySupermarkets[supermarket].Add(product, price);
                }
                else
                {
                    productsWithPricesBySupermarkets[supermarket][product] = price;
                }
            }

            foreach (var kvp in productsWithPricesBySupermarkets)
            {
                Console.WriteLine($"{kvp.Key}->");

                foreach (var nestedkvp in kvp.Value)
                {
                    Console.WriteLine($"Product: {nestedkvp.Key}, Price: {nestedkvp.Value}");
                }
            }
        }
    }
}
