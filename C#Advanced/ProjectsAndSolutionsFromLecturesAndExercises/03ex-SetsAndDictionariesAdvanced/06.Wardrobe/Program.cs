using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputLines = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothesByColorWithTheirCount = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfInputLines; i++)
            {
                string[] lineParts = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = lineParts[0];

                if (!clothesByColorWithTheirCount.ContainsKey(color))
                {
                    clothesByColorWithTheirCount.Add(color, new Dictionary<string, int>());

                }

                string[] clothes = lineParts[1]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries);

                foreach (string clothe in clothes)
                {
                    if (!clothesByColorWithTheirCount[color].ContainsKey(clothe))
                    {
                        clothesByColorWithTheirCount[color].Add(clothe, 0);
                    }

                    clothesByColorWithTheirCount[color][clothe]++;
                }
            }

            string[] targetColorAndClothe = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string targetColor = targetColorAndClothe[0];
            string targetClothe = targetColorAndClothe[1];

            foreach (var kvp in clothesByColorWithTheirCount)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var nestedKVP in kvp.Value)
                {
                    if (kvp.Key == targetColor && nestedKVP.Key == targetClothe)
                    {
                        Console.WriteLine($"* {nestedKVP.Key} - {nestedKVP.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {nestedKVP.Key} - {nestedKVP.Value}");
                    }
                }
            }
        }
    }
}
