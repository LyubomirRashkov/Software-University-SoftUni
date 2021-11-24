using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double moneyInserted = 0;
            double availableSum = 0;

            while (input != "Start")
            {
                moneyInserted = double.Parse(input);

                if (moneyInserted == 0.1 || moneyInserted == 0.2 || moneyInserted == 0.5 || moneyInserted == 1 || moneyInserted == 2)
                {
                    availableSum += moneyInserted;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {moneyInserted}");
                }

                input = Console.ReadLine();
            }

            string newInput = Console.ReadLine();
            double productPrice = 0;

            while (newInput != "End")
            {
                if (newInput == "Nuts")
                {
                    productPrice = 2;
                }
                else if (newInput == "Water")
                {
                    productPrice = 0.7;
                }
                else if (newInput == "Crisps")
                {
                    productPrice = 1.5;
                }
                else if (newInput == "Soda")
                {
                    productPrice = 0.8;
                }
                else if (newInput == "Coke")
                {
                    productPrice = 1;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    newInput = Console.ReadLine();
                    continue;
                }

                if (availableSum >= productPrice)
                {
                    Console.WriteLine($"Purchased {newInput.ToLower()}");
                    availableSum -= productPrice;
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                newInput = Console.ReadLine();
            }

            Console.WriteLine($"Change: {availableSum:F2}");
        }
    }
}
