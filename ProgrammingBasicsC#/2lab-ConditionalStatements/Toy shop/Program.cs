using System;

namespace Toy_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double moneyFromAllToys = (puzzles * 2.60) + (dolls * 3) + (bears * 4.10) + (minions * 8.20) + (trucks * 2);
            int numberOfToys = puzzles + dolls + bears + minions + trucks;

            if (numberOfToys >= 50)
            {
                moneyFromAllToys = moneyFromAllToys - (0.25 * moneyFromAllToys);
            }

            double profitAfterRent = moneyFromAllToys * 0.9;

            if (profitAfterRent >= tripPrice)
            {
                Console.WriteLine($"Yes! {(profitAfterRent - tripPrice):f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {(tripPrice - profitAfterRent):f2} lv needed.");
            }
        }
    }
}
