using System;

namespace _02._Cat_Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutes = int.Parse(Console.ReadLine());
            int numberOfWalkigs = int.Parse(Console.ReadLine());
            int calories = int.Parse(Console.ReadLine());

            int burnedCalories = (minutes * 5) * numberOfWalkigs;

            if (burnedCalories >= calories * 0.5)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {burnedCalories}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {burnedCalories}.");
            }
        }
    }
}
