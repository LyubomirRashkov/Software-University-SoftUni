using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsAndPasswords = new Dictionary<string, string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of contests")
                {
                    break;
                }

                string[] lineParts = line
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                string contest = lineParts[0];
                string password = lineParts[1];

                if (!contestsAndPasswords.ContainsKey(contest))
                {
                    contestsAndPasswords.Add(contest, password);
                }
            }

            SortedDictionary<string, Dictionary<string, int>> contestsWithPointsByParticipant = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of submissions")
                {
                    break;
                }

                string[] lineParts = line
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = lineParts[0];
                string password = lineParts[1];
                string participant = lineParts[2];
                int points = int.Parse(lineParts[3]);

                if (!contestsAndPasswords.ContainsKey(contest) || contestsAndPasswords[contest] != password)
                {
                    continue;
                }

                if (!contestsWithPointsByParticipant.ContainsKey(participant))
                {
                    contestsWithPointsByParticipant.Add(participant, new Dictionary<string, int>());
                }

                if (!contestsWithPointsByParticipant[participant].ContainsKey(contest))
                {
                    contestsWithPointsByParticipant[participant].Add(contest, points);
                }
                else if (contestsWithPointsByParticipant[participant][contest] < points)
                {
                    contestsWithPointsByParticipant[participant][contest] = points;
                }
            }

            long maxPoints = int.MinValue;
            string bestCandidate = string.Empty;

            foreach (var kvp in contestsWithPointsByParticipant)
            {
                long currentParticipantPoints = kvp.Value.Sum(x => x.Value);

                if (maxPoints < currentParticipantPoints)
                {
                    maxPoints = currentParticipantPoints;
                    bestCandidate = kvp.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var kvp in contestsWithPointsByParticipant)
            {
                Console.WriteLine(kvp.Key);

                foreach (var nestedKVP in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {nestedKVP.Key} -> {nestedKVP.Value}");
                }
            }
        }
    }
}
