using System;

namespace _01._Guinea_Pig
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal food = decimal.Parse(Console.ReadLine());
            decimal hay = decimal.Parse(Console.ReadLine());
            decimal cover = decimal.Parse(Console.ReadLine());
            decimal weight = decimal.Parse(Console.ReadLine());

            bool areEnough = true;

            for (int i = 1; i <= 30; i++)
            {
                food -= 0.3m;

                if (i % 2 == 0)
                {
                    hay -= (0.05m * food);
                }

                if (i % 3 == 0)
                {
                    cover -= ((1.0m / 3) * weight);
                }

                if (food <= 0 || hay <= 0 || cover <= 0)
                {
                    areEnough = false;
                    Console.WriteLine("Merry must go to the pet store!");
                    break;
                }
            }

            if (areEnough)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:F2}, Hay: {hay:F2}, Cover: {cover:F2}.");
            }
        }
    }
}
