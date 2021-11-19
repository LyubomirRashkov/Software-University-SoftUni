using System;

namespace _03._Energy_Booster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int numberOfSets = int.Parse(Console.ReadLine());

            double pricePerOneSet = 0;

            switch (fruit)
            {
                case "Watermelon":
                    if (size == "small")
                    {
                        pricePerOneSet = 2 * 56;
                    }
                    else if (size == "big")
                    {
                        pricePerOneSet = 5 * 28.70;
                    }
                    break;
                case "Mango":
                    if(size == "small")
                    {
                        pricePerOneSet = 2 * 36.66;
                    }
                    else if (size == "big")
                    {
                        pricePerOneSet = 5 * 19.60;
                    }
                    break;
                case "Pineapple":
                    if(size == "small")
                    {
                        pricePerOneSet = 2 * 42.10;
                    }
                    else if (size == "big")
                    {
                        pricePerOneSet = 5 * 24.80;
                    }
                    break;
                case "Raspberry":
                    if(size == "small")
                    {
                        pricePerOneSet = 2 * 20;
                    }
                    else if (size == "big")
                    {
                        pricePerOneSet = 5 * 15.20;
                    }
                    break;
            }

            double priceForAllSets = pricePerOneSet * numberOfSets;

            if (priceForAllSets > 1000)
            {
                priceForAllSets *= 0.5;
            }
            else if (priceForAllSets >= 400)
            {
                priceForAllSets *= 0.85;
            }

            Console.WriteLine($"{priceForAllSets:f2} lv.");
        }
    }
}
