using System;

namespace Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {

                //            Да се отпечата на конзолата един ред:
                //           •   Ако бюджетът е достатъчен:
                //            "Yes! You have {останалите пари} leva left."
                //           •	Ако бюджетът НЕ Е достатъчен:
                //            "Not enough money! You need {сумата, която не достига} leva."
                   //         Сумите трябва да са форматирани с точност до два знака след десетичната запетая.


            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());

            double price = 0;

            switch (season)
            {
                case "Spring":
                    price = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    price = 4200;
                    break;
                case "Winter":
                    price = 2600;
                    break;
            }

            if (fishermen <= 6)
            {
                price = price * 0.9;
            }
            else if (fishermen > 7 && fishermen <= 11)
            {
                price = price * 0.85;
            }
            else if (fishermen >= 12)
            {
                price = price * 0.75;
            }

            if (fishermen % 2 == 0 && season != "Autumn")
            {
                price = price * 0.95;
            }

            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {(budget - price):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(price - budget):f2} leva.");
            }
        }
    }
}
