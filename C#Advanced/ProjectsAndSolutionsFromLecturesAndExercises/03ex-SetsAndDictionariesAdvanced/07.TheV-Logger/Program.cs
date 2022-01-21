using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        public class Vlogger
        {
            public Vlogger()
            {
                this.Followers = new HashSet<string>();

                this.Following = new HashSet<string>();
            }

            public string Name { get; set; }

            public HashSet<string> Followers { get; set; }

            public HashSet<string> Following { get; set; }
        }

        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Statistics")
                {
                    break;
                }

                string[] lineParts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (lineParts[1] == "joined")
                {
                    string vloggerName = lineParts[0];

                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        Vlogger vlogger = new Vlogger
                        {
                            Name = vloggerName
                        };

                        vloggers.Add(vloggerName, vlogger);
                    }
                }
                else if (lineParts[1] == "followed")
                {
                    string firstVlogger = lineParts[0];
                    string secondVlogger = lineParts[2];

                    if (firstVlogger == secondVlogger
                        || !vloggers.ContainsKey(firstVlogger)
                        || !vloggers.ContainsKey(secondVlogger))
                    {
                        continue;
                    }

                    vloggers[firstVlogger].Following.Add(secondVlogger);
                    vloggers[secondVlogger].Followers.Add(firstVlogger);
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            Dictionary<string, Vlogger> sortedVloggers = vloggers
                .OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            int counter = 1;

            foreach (var kvp in sortedVloggers)
            {
                Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value.Followers.Count} followers, {kvp.Value.Following.Count} following");

                if (counter == 1)
                {
                    if (kvp.Value.Followers.Count != 0)
                    {
                        List<string> followers = kvp.Value.Followers.OrderBy(x => x).ToList();

                        foreach (string follower in followers)
                        {
                            Console.WriteLine($"*  {follower}");
                        }
                    }
                }

                counter++;
            }
        }
    }
}
