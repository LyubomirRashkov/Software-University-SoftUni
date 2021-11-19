using System;

namespace _05._PC_Game_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGames = int.Parse(Console.ReadLine());

            int counterHearthstone = 0;
            int counterFornite = 0;
            int counterOverwatch = 0;
            int counterOthers = 0;
            double counterAll = 0;

            for (int i = 1; i <= numberOfGames; i++)
            {
                string nameOfTheGame = Console.ReadLine();

                switch (nameOfTheGame)
                {
                    case "Hearthstone":
                        counterHearthstone++;
                        break;
                    case "Fornite":
                        counterFornite++;
                        break;
                    case "Overwatch":
                        counterOverwatch++;
                        break;
                    default:
                        counterOthers++;
                        break;
                }
                counterAll++;
            }

            Console.WriteLine($"Hearthstone - {((counterHearthstone * 100) / counterAll):f2}%");
            Console.WriteLine($"Fornite - {((counterFornite * 100) / counterAll):f2}%");
            Console.WriteLine($"Overwatch - {((counterOverwatch * 100) / counterAll):f2}%");
            Console.WriteLine($"Others - {((counterOthers * 100) / counterAll):f2}%");
        }
    }
}
