using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BakeryShop
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, double> percentWaterByProduct = new Dictionary<string, double>
            {
                { "Croissant", 50 },
                { "Muffin", 40 },
                { "Baguette", 30 },
                { "Bagel", 20 }
            };

            Queue<double> waters = new Queue<double>(Console.ReadLine()
                                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                       .Select(double.Parse)
                                                       .ToArray());

            Stack<double> flours = new Stack<double>(Console.ReadLine()
                                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                       .Select(double.Parse)
                                                       .ToArray());

            Dictionary<string, int> countOfBakedProductsByProduct = new Dictionary<string, int>();

            while (waters.Any() && flours.Any())
            {
                double currentWater = waters.Dequeue();
                double currentFlour = flours.Pop();

                double result = (currentWater * 100) / (currentWater + currentFlour);

                bool isProductBaked = false;

                foreach (var kvp in percentWaterByProduct)
                {
                    if (result == kvp.Value)
                    {
                        isProductBaked = true;

                        if (!countOfBakedProductsByProduct.ContainsKey(kvp.Key))
                        {
                            countOfBakedProductsByProduct.Add(kvp.Key, 0);
                        }

                        countOfBakedProductsByProduct[kvp.Key]++;
                        break;
                    }
                }

                if (!isProductBaked)
                {
                    if (!countOfBakedProductsByProduct.ContainsKey("Croissant"))
                    {
                        countOfBakedProductsByProduct.Add("Croissant", 0);
                    }

                    countOfBakedProductsByProduct["Croissant"]++;

                    flours.Push(currentFlour - currentWater);
                }
            }

            countOfBakedProductsByProduct = countOfBakedProductsByProduct
                                                .OrderByDescending(kvp => kvp.Value)
                                                .ThenBy(kvp => kvp.Key)
                                                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in countOfBakedProductsByProduct)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            if (waters.Any())
            {
                Console.WriteLine($"Water left: {string.Join(", ", waters)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flours.Any())
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flours)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
