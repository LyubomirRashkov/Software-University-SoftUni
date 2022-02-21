using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private Dictionary<string, Racer> data;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new Dictionary<string, Racer>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Racer Racer)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(Racer.Name, Racer);
            }
        }

        public bool Remove(string name) => this.data.Remove(name);

        public Racer GetOldestRacer() => this.data.OrderByDescending(kvp => kvp.Value.Age).First().Value;

        public Racer GetRacer(string name) => this.data[name];

        public Racer GetFastestRacer() => this.data.OrderByDescending(kvp => kvp.Value.Car.Speed).First().Value;

        public string Report() 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}:");

            foreach (var kvp in this.data)
            {
                sb.AppendLine(kvp.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
