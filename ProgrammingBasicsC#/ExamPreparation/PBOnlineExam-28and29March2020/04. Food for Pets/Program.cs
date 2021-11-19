using System;

namespace _04._Food_for_Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double foodAmount = double.Parse(Console.ReadLine());

            double allFoodEatenByTheDog = 0;
            double allFoodEatenByTheCat = 0;

            double bisquitAmount = 0;
            double totalBisquitAmount = 0;

            for (int i = 1; i <= days; i++)
            {
                double foodEatenByTheDogForOneDay = double.Parse(Console.ReadLine());
                double foodEatenByTheCatForOneDay = double.Parse(Console.ReadLine());

                allFoodEatenByTheDog += foodEatenByTheDogForOneDay;
                allFoodEatenByTheCat += foodEatenByTheCatForOneDay;

                if (i % 3 == 0)
                {
                    bisquitAmount = 0.1 * (foodEatenByTheDogForOneDay + foodEatenByTheCatForOneDay);
                }
                else
                {
                    bisquitAmount = 0;
                }

                totalBisquitAmount += bisquitAmount;
            }

            Console.WriteLine($"Total eaten biscuits: {Math.Round(totalBisquitAmount)}gr.");
            Console.WriteLine($"{(((allFoodEatenByTheDog + allFoodEatenByTheCat) * 100) / foodAmount):f2}% of the food has been eaten.");
            Console.WriteLine($"{((allFoodEatenByTheDog * 100) / (allFoodEatenByTheDog + allFoodEatenByTheCat)):f2}% eaten from the dog.");
            Console.WriteLine($"{((allFoodEatenByTheCat * 100) / (allFoodEatenByTheDog + allFoodEatenByTheCat)):f2}% eaten from the cat.");
        }
    }
}
