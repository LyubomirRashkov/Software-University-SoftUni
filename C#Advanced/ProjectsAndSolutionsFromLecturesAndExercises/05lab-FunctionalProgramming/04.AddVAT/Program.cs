using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            double[] pricesWithVAT = prices
                .Select(pr => pr * 1.2)
                .ToArray();

            foreach (double price in pricesWithVAT)
            {
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
