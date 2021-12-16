using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> pointsByUser = new Dictionary<string, int>();

            Dictionary<string, int> submissionsCountByLanguage = new Dictionary<string, int>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "exam finished")
                {
                    break;
                }

                string[] parts = line
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                string username = parts[0];

                if (parts[1] != "banned")
                {
                    string language = parts[1];
                    int points = int.Parse(parts[2]);

                    if (pointsByUser.ContainsKey(username))
                    {
                        if (pointsByUser[username] < points)
                        {
                            pointsByUser[username] = points;
                        }
                    }
                    else
                    {
                        pointsByUser.Add(username, points);
                    }

                    if (submissionsCountByLanguage.ContainsKey(language))
                    {
                        submissionsCountByLanguage[language]++;
                    }
                    else
                    {
                        submissionsCountByLanguage.Add(language, 1);
                    }
                }
                else
                {
                    pointsByUser.Remove(username);
                }
            }

            Dictionary<string, int> sortedPointsByUser = pointsByUser
                .OrderByDescending(u => u.Value)
                .ThenBy(u => u.Key)
                .ToDictionary(u => u.Key, u => u.Value);

            Console.WriteLine("Results:");

            foreach (var kvp in sortedPointsByUser)
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Dictionary<string, int> sortedSubmissionsCountByLanguage = submissionsCountByLanguage
                .OrderByDescending(s => s.Value)
                .ThenBy(s => s.Key)
                .ToDictionary(s => s.Key, s => s.Value);

            Console.WriteLine("Submissions:");

            foreach (var kvp in sortedSubmissionsCountByLanguage)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
