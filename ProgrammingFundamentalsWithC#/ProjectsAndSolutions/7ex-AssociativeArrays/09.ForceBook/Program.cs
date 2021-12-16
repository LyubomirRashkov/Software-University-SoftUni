using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> sideByUser = new Dictionary<string, string>();

            Dictionary<string, List<string>> usersBySide = new Dictionary<string, List<string>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Lumpawaroo")
                {
                    break;
                }

                if (line.Contains(" | "))
                {
                    string[] parts = line
                        .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    string side = parts[0];
                    string user = parts[1];

                    if (!sideByUser.ContainsKey(user))
                    {
                        sideByUser.Add(user, side);

                        if (!usersBySide.ContainsKey(side))
                        {
                            usersBySide.Add(side, new List<string>() { user });
                        }
                        else
                        {
                            usersBySide[side].Add(user);
                        }
                    }
                }
                else
                {
                    string[] parts = line
                        .Split(" -> ");

                    string user = parts[0];
                    string side = parts[1];

                    if (sideByUser.ContainsKey(user))
                    {
                        string oldSide = sideByUser[user];
                        sideByUser[user] = side;
                        usersBySide[oldSide].Remove(user);

                        if (usersBySide.ContainsKey(side))
                        {
                            usersBySide[side].Add(user);
                        }
                        else
                        {
                            usersBySide.Add(side, new List<string>() { user });
                        }
                    }
                    else
                    {
                        sideByUser.Add(user, side);

                        if (usersBySide.ContainsKey(side))
                        {
                            usersBySide[side].Add(user);
                        }
                        else
                        {
                            usersBySide.Add(side, new List<string>() { user });
                        }
                    }

                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            Dictionary<string, List<string>> sorted = usersBySide
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sorted)
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                kvp.Value.Sort();

                foreach (var user in kvp.Value)
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
