using System;

namespace _04._Series
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int filmCounter = int.Parse(Console.ReadLine());
            string filmName = "";
            double filmPrice = 0;
            double requiredMoney = 0;

            for (int i = 1; i <= filmCounter; i++)
            {
                filmName = Console.ReadLine();
                filmPrice = double.Parse(Console.ReadLine());
                if (filmName == "Thrones")
                {
                    filmPrice *= 0.5;
                }
                else if (filmName == "Lucifer")
                {
                    filmPrice *= 0.6;
                }
                else if (filmName == "Protector")
                {
                    filmPrice *= 0.7;
                }
                else if (filmName == "TotalDrama")
                {
                    filmPrice *= 0.8;
                }
                else if (filmName == "Area")
                {
                    filmPrice *= 0.9;
                }
                requiredMoney += filmPrice;
            }

            if (budget >= requiredMoney)
            {
                Console.WriteLine($"You bought all the series and left with {(budget - requiredMoney):f2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {(requiredMoney - budget):f2} lv. more to buy the series!");
            }
        }
    }
}
