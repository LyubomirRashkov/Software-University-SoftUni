using System;

namespace _02._Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double litres = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            double price = (litres * 2.10) + 100;

            if (day == "Saturday")
            {
                price *= 0.9;
            }
            else
            {
                price *= .8;
            }

            if (budget >= price)
            {
                Console.WriteLine($"Safari time! Money left: {(budget - price):f2} lv. ");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {(price - budget):f2} lv.");
            }

        }
    }
}
