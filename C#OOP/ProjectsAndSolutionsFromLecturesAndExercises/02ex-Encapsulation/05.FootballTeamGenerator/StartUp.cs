using System;
using System.Collections.Generic;

namespace _05.FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Team> teamsByName = new Dictionary<string, Team>();

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "END")
                {
                    break;
                }

                string[] commandInfo = inputLine.Split(';', StringSplitOptions.RemoveEmptyEntries);

                string command = commandInfo[0];
                string teamName = commandInfo[1];

                if (command == "Team")
                {
                    try
                    {
                        Team team = new Team(teamName);

                        teamsByName.Add(team.Name, team);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Add")
                {
                    if (!teamsByName.ContainsKey(teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");

                        continue;
                    }

                    string playerName = commandInfo[2];
                    int endurance = int.Parse(commandInfo[3]);
                    int sprint = int.Parse(commandInfo[4]);
                    int dribble = int.Parse(commandInfo[5]);
                    int passing = int.Parse(commandInfo[6]);
                    int shooting = int.Parse(commandInfo[7]);

                    try
                    {
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        teamsByName[teamName].AddPlayer(player);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Remove")
                {
                    string playerName = commandInfo[2];

                    try
                    {
                        teamsByName[teamName].RemovePlayer(playerName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Rating")
                {
                    if (!teamsByName.ContainsKey(teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");

                        continue;
                    }

                    Console.WriteLine($"{teamName} - {teamsByName[teamName].Rating}");
                }
            }
        }
    }
}
