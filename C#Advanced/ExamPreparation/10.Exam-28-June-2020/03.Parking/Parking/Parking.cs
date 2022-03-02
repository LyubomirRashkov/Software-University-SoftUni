using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private Dictionary<string, Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new Dictionary<string, Car>();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Car car)
        {
            if (this.Capacity > this.data.Count)
            {
                string key = car.Manufacturer + " " + car.Model;

                this.data.Add(key, car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            string key = manufacturer + " " + model;

            return this.data.Remove(key);
        }

        public Car GetLatestCar() => this.data.OrderByDescending(kvp => kvp.Value.Year).FirstOrDefault().Value;

        public Car GetCar(string manufacturer, string model)
        {
            string key = manufacturer + " " + model;

            if (this.data.ContainsKey(key))
            {
                return this.data[key];
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var kvp in this.data)
            {
                sb.AppendLine(kvp.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
