using System;

namespace _03._Fitness_Card
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            char sex = char.Parse(Console.ReadLine());
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double cardPrice = 0;

            switch (sport)
            {
                case "Gym":
                    if (sex == 'm')
                    {
                        cardPrice = 42;
                    }
                    else if (sex == 'f')
                    {
                        cardPrice = 35;
                    }
                    break;
                case "Boxing":
                    if (sex == 'm')
                    {
                        cardPrice = 41;
                    }
                    else if (sex == 'f')
                    {
                        cardPrice = 37;
                    }
                    break;
                case "Yoga":
                    if (sex == 'm')
                    {
                        cardPrice = 45;
                    }
                    else if (sex == 'f')
                    {
                        cardPrice = 42;
                    }
                    break;
                case "Zumba":
                    if (sex == 'm')
                    {
                        cardPrice = 34;
                    }
                    else if (sex == 'f')
                    {
                        cardPrice = 31;
                    }
                    break;
                case "Dances":
                    if (sex == 'm')
                    {
                        cardPrice = 51;
                    }
                    else if (sex == 'f')
                    {
                        cardPrice = 53;
                    }
                    break;
                case "Pilates":
                    if (sex == 'm')
                    {
                        cardPrice = 39;
                    }
                    else if (sex == 'f')
                    {
                        cardPrice = 37;
                    }
                    break;
            }

            if (age <= 19)
            {
                cardPrice *= 0.8;
            }

            if (budget >= cardPrice)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${(cardPrice - budget):f2} more.");
            }
        }
    }
}
