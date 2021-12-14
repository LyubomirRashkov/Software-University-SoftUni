using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    public class Team
    {
        public Team()
        {
            Members = new List<string>();
        }

        public string TeamName { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>(numberOfTeams);

            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] teamData = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                string creator = teamData[0];
                string teamName = teamData[1];

                Team existingTeam = teams
                    .FirstOrDefault(t => t.TeamName == teamName);

                if (existingTeam != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (IsCreatorExisting(teams, creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team team = new Team
                {
                    Creator = creator,
                    TeamName = teamName
                };

                teams.Add(team);

                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of assignment")
                {
                    break;
                }

                string[] teamData = line
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                string user = teamData[0];
                string teamName = teamData[1];

                Team existingTeam = teams
                    .FirstOrDefault(t => t.TeamName == teamName);

                if (existingTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (IsMemberExisting(teams, user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }

                existingTeam.Members.Add(user);
            }

            List<Team> sortedValidTeams = teams
                .Where(t => t.Members.Count > 0)
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.TeamName)
                .ToList();

            foreach (Team team in sortedValidTeams)
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");

                List<string> sortedMembers = team.Members
                    .OrderBy(t => t)
                    .ToList();

                foreach (string member in sortedMembers)
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            List<Team> teamsToDisband = teams
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.TeamName)
                .ToList();

            Console.WriteLine("Teams to disband:");

            foreach (Team team in teamsToDisband)
            {
                Console.WriteLine($"{team.TeamName}");
            }
        }

        private static bool IsMemberExisting(List<Team> teams, string user)
        {
            foreach (Team team in teams)
            {
                if (team.Creator == user || team.Members.Contains(user))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsCreatorExisting(List<Team> teams, string creator)
        {
            foreach (Team team in teams)
            {
                if (team.Creator == creator)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
