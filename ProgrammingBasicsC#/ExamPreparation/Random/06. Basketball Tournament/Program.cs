using System;

namespace _06._Basketball_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string tournamentName = Console.ReadLine();

            int counterOfWins = 0;
            int counterOfLosses = 0;

            while (tournamentName != "End of tournaments")
            {
                int numberOfMatches = int.Parse(Console.ReadLine());
                int counterOfMatches = 0;

                for (int i = 1; i <= numberOfMatches; i++)
                {
                    int pointsOfDesi = int.Parse(Console.ReadLine());
                    int pointsOfOpponent = int.Parse(Console.ReadLine());
                    counterOfMatches++;

                    if (pointsOfDesi > pointsOfOpponent)
                    {
                        counterOfWins++;
                        Console.WriteLine($"Game {counterOfMatches} of tournament {tournamentName}: win with {pointsOfDesi - pointsOfOpponent} points.");
                    }
                    else
                    {
                        counterOfLosses++;
                        Console.WriteLine($"Game {counterOfMatches} of tournament {tournamentName}: lost with {pointsOfOpponent - pointsOfDesi} points.");
                    }
                }

                tournamentName = Console.ReadLine();
            }

            Console.WriteLine($"{((counterOfWins * 100.0) / (counterOfWins + counterOfLosses)):f2}% matches win");
            Console.WriteLine($"{((counterOfLosses * 100.0) / (counterOfWins + counterOfLosses)):f2}% matches lost");
        }
    }
}
