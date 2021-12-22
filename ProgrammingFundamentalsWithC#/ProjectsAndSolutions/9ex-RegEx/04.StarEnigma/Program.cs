using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());

            Regex keyRegex = new Regex(@"[STARstar]");

            Regex infoRegex = new Regex(@"@(?<planetName>[A-Z]+[a-z]*)([^@\-!:>]*?):(?<population>[\d]+)([^@\-!:>]*?)!(?<type>[AD])!([^@\-!:>])*->(?<soldiersCount>\d+)");

            List<string> attackedPlanets = new List<string>();

            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < numberOfMessages; i++)
            {
                string inputMessage = Console.ReadLine();

                MatchCollection matches = keyRegex.Matches(inputMessage);

                int keyNumber = matches.Count;

                StringBuilder sb = new StringBuilder();

                foreach (char symbol in inputMessage)
                {
                    char newSymbol = (char)(symbol - keyNumber);

                    sb.Append(newSymbol);
                }

                string decryptedMessage = sb.ToString();

                Match match = infoRegex.Match(decryptedMessage);

                if (!match.Success)
                {
                    continue;
                }

                string planetName = match.Groups["planetName"].Value;
                string type = match.Groups["type"].Value;

                if (type == "A")
                {
                    attackedPlanets.Add(planetName);
                }
                else
                {
                    destroyedPlanets.Add(planetName);
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            SortAndPrint(attackedPlanets);

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            SortAndPrint(destroyedPlanets);
        }

        private static void SortAndPrint(List<string> collection)
        {
            collection.Sort();

            foreach (string planetName in collection)
            {
                Console.WriteLine($"-> {planetName}");
            }
        }
    }
}
