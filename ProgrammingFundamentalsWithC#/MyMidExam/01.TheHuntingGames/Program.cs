using System;

namespace _01.TheHuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysCount = int.Parse(Console.ReadLine());
            int numberOfPlayers = int.Parse(Console.ReadLine());
            double energyOfTheGroup = double.Parse(Console.ReadLine());
            double waterPerDayForOnePerson = double.Parse(Console.ReadLine());
            double foodPerDayForOnePerson = double.Parse(Console.ReadLine());

            double waterOfTheGroup = daysCount * numberOfPlayers * waterPerDayForOnePerson;
            double foodOfTheGroup = daysCount * numberOfPlayers * foodPerDayForOnePerson;

            bool haveEnergy = true;

            for (int i = 1; i <= daysCount; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());

                energyOfTheGroup -= energyLoss;

                if (energyOfTheGroup <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {foodOfTheGroup:F2} food and {waterOfTheGroup:F2} water.");
                    haveEnergy = false;
                    break;
                }

                if (i % 2 == 0)
                {
                    energyOfTheGroup *= 1.05;
                    waterOfTheGroup *= 0.7;
                }

                if (i % 3 == 0)
                {
                    foodOfTheGroup -= (foodOfTheGroup / numberOfPlayers);
                    energyOfTheGroup *= 1.1;
                }
            }

            if (haveEnergy)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energyOfTheGroup:F2} energy!");
            }
        }
    }
}
