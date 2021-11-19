using System;

namespace _04._Tourist_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            double requiredMoney = 0;
            int counter = 0;

            while (input != "Stop")
            {
                double productPrice = double.Parse(Console.ReadLine());

                counter++;
                if (counter % 3 == 0)
                {
                    productPrice /= 2;
                }

                if (productPrice > (budget - requiredMoney))
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {(productPrice - (budget - requiredMoney)):f2} leva!");
                    break;
                }

                requiredMoney += productPrice;

                input = Console.ReadLine();
            }

            if (input == "Stop")
            {
                Console.WriteLine($"You bought {counter} products for {requiredMoney:f2} leva.");
            }
        }
    }
}
