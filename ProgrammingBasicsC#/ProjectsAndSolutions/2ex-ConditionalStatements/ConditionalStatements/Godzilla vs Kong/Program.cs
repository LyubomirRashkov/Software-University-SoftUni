using System;

namespace Godzilla_vs_Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfActors = int.Parse(Console.ReadLine());
            double pricePerClothingForOneActor = double.Parse(Console.ReadLine());

            double necessaryMoney = 0;

            if (numberOfActors > 150)
            {
                necessaryMoney = (0.1 * budget) + numberOfActors * (0.9 * pricePerClothingForOneActor);
            }
            else
            {
                necessaryMoney = (0.1 * budget) + (numberOfActors * pricePerClothingForOneActor);
            }

            if (necessaryMoney > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(necessaryMoney - budget):f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {(budget - necessaryMoney):f2} leva left.");
            }
        }
    }
}
