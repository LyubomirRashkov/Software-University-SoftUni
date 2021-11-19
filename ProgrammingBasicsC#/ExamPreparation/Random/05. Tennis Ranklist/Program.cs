using System;

namespace _05._Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTournaments = int.Parse(Console.ReadLine());
            double startPoints = double.Parse(Console.ReadLine());

            int addPoints = 0;
            double allAddPoints = 0;
            double allPoints = 0;
            int counterWins = 0;
            int counterAll = 0;

            for (int i = 1; i <= numberOfTournaments; i++)
            {
                string stage = Console.ReadLine();
                counterAll++;

                switch (stage)
                {
                    case "W":
                        addPoints = 2000;
                        counterWins++;
                        break;
                    case "F":
                        addPoints = 1200;
                        break;
                    case "SF":
                        addPoints = 720;
                        break;
                }
                allAddPoints += addPoints;
            }
            allPoints = startPoints + allAddPoints;

            Console.WriteLine($"Final points: {allPoints}");
            Console.WriteLine($"Average points: {Math.Floor(allAddPoints / numberOfTournaments)}");
            Console.WriteLine($"{((counterWins * 100.0) / counterAll):f2}%");
        }
    }
}
