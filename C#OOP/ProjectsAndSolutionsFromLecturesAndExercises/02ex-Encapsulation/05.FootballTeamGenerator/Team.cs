using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private const string NameExceptionMessage = "A name should not be empty.";

        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            { 
                return this.name; 
            }

            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(NameExceptionMessage);
                }

                this.name = value; 
            }
        }

        public int Rating 
        {
            get 
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                return (int)Math.Round(this.players.Average(p => p.SkillLevel));
            }
        }

        public void AddPlayer(Player player) 
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName) 
        {
            Player currentPlayer = this.players.FirstOrDefault(p => p.Name == playerName);

            if (currentPlayer == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            this.players.Remove(currentPlayer);
        }
    }
}
