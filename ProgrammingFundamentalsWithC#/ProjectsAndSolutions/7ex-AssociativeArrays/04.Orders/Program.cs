using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> priceByProduct = new Dictionary<string, decimal>();

            Dictionary<string, int> quantityByProduct = new Dictionary<string, int>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "buy")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string product = parts[0];
                decimal price = decimal.Parse(parts[1]);
                int quantity = int.Parse(parts[2]);

                if (priceByProduct.ContainsKey(product))
                {
                    priceByProduct[product] = price;
                    quantityByProduct[product] += quantity;
                }
                else
                {
                    priceByProduct.Add(product, price);
                    quantityByProduct.Add(product, quantity);
                }
            }

            foreach (var kvp in priceByProduct)
            {
                Console.WriteLine($"{kvp.Key} -> {(kvp.Value * quantityByProduct[kvp.Key]):F2}");
            }
        }
    }
}
