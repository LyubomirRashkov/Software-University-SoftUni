using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> distanceByRacer = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(x => x, x => 0);

            Regex lettersRegex = new Regex(@"[A-Za-z]");
            Regex digitsRegex = new Regex(@"[\d]");

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of race")
                {
                    break;
                }

                MatchCollection lettersMatches = lettersRegex.Matches(line);

                if (lettersMatches.Count == 0)
                {
                    continue;
                }

                string racerName = BuildName(lettersMatches);


                if (distanceByRacer.ContainsKey(racerName))
                {
                    MatchCollection digitsMatches = digitsRegex.Matches(line);

                    if (digitsMatches.Count == 0)
                    {
                        continue;
                    }

                    int distance = CalculateSum(digitsMatches);

                    distanceByRacer[racerName] += distance;
                }
            }

            string[] racers = distanceByRacer
                .OrderByDescending(x => x.Value)
                .Take(3)
                .Select(x => x.Key)
                .ToArray();

            Console.WriteLine($"1st place: {racers[0]}");
            Console.WriteLine($"2nd place: {racers[1]}");
            Console.WriteLine($"3rd place: {racers[2]}");
        }

        private static int CalculateSum(MatchCollection matches)
        {
            int sum = 0;

            foreach (Match match in matches)
            {
                sum += int.Parse(match.Value);
            }

            return sum;
        }

        private static string BuildName(MatchCollection matches)
        {
            StringBuilder name = new StringBuilder();

            foreach (Match match in matches)
            {
                name.Append(match.Value);
            }

            return name.ToString();
        }
    }
}
