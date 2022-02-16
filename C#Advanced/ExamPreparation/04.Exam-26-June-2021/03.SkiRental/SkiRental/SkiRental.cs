using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Ski>();
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

        public void Add(Ski ski)
        {
            if (this.Capacity > this.data.Count)
            {
                this.data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            foreach (Ski ski in this.data)
            {
                if (ski.Manufacturer == manufacturer && ski.Model == model)
                {
                    this.data.Remove(ski);

                    return true;
                }
            }

            return false;
        }

        public Ski GetNewestSki() => this.data.OrderByDescending(d => d.Year).FirstOrDefault();

        public Ski GetSki(string manufacturer, string model)
        {
            foreach (Ski ski in this.data)
            {
                if (ski.Manufacturer == manufacturer && ski.Model == model)
                {
                    return ski;
                }
            }

            return null;
        }

        public string GetStatistics() 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {this.Name}:");

            foreach (Ski ski in this.data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
