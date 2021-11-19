using System;

namespace _05._Football_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int numberOfGames = int.Parse(Console.ReadLine());
            int points = 0;
            double counterW = 0;
            int counterD = 0;
            int counterL = 0;

            for (int i = 1; i <= numberOfGames; i++)
            {
                char result = char.Parse(Console.ReadLine());
                switch (result)
                {
                    case 'W':
                        points += 3;
                        counterW++;
                        break;
                    case 'D':
                        points += 1;
                        counterD++;
                        break;
                    case 'L':
                        counterL++;
                        break;
                }

            }

            if (numberOfGames == 0)
            {
                Console.WriteLine($"{teamName} hasn't played any games during this season.");
            }
            else
            {
                Console.WriteLine($"{teamName} has won {points} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {counterW}");
                Console.WriteLine($"## D: {counterD}");
                Console.WriteLine($"## L: {counterL}");
                Console.WriteLine($"Win rate: {(counterW * 100) / (counterW + counterD + counterL):f2}%");
            }
        }
    }
}
