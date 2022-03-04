using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.roster.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            if (this.Capacity > this.roster.Count)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            for (int i = 0; i < this.roster.Count; i++)
            {
                if (this.roster[i].Name == name)
                {
                    this.roster.RemoveAt(i);

                    return true;
                }
            }

            return false;
        }

        public void PromotePlayer(string name) => this.roster.First(p => p.Name == name).Rank = "Member";

        public void DemotePlayer(string name) => this.roster.First(p => p.Name == name).Rank = "Trial";

        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> removed = new List<Player>();

            for (int i = 0; i < this.roster.Count; i++)
            {
                if (this.roster[i].Class == @class)
                {
                    removed.Add(this.roster[i]);

                    this.roster.RemoveAt(i);
                    i--;
                }
            }

            return removed.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (Player player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
