using System;

namespace _05._Care_of_Puppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int purchasedFood = int.Parse(Console.ReadLine());
            int purchasedFoodInGrs = purchasedFood * 1000;

            string input = Console.ReadLine();

            int allEatenFood = 0;

            while (input != "Adopted")
            {
                int eatenFood = int.Parse(input);
                allEatenFood += eatenFood;
                input = Console.ReadLine();
            }

            if (purchasedFoodInGrs >= allEatenFood)
            {
                Console.WriteLine($"Food is enough! Leftovers: {purchasedFoodInGrs - allEatenFood} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {allEatenFood - purchasedFoodInGrs} grams more.");
            }
        }
    }
}
