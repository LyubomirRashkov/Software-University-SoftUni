using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.Participants = new Dictionary<string, Car>();
        }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public int Laps { get; private set; }

        public int Capacity { get; private set; }

        public int MaxHorsePower { get; private set; }

        private Dictionary<string, Car> Participants { get; set; }

        public int Count => this.Participants.Count;

        public void Add(Car car) 
        {
            if (!this.Participants.ContainsKey(car.LicensePlate) 
                && this.Count < this.Capacity 
                && car.HorsePower <= this.MaxHorsePower)
            {
                this.Participants.Add(car.LicensePlate, car);
            }
        }

        public bool Remove(string licensePlate) => this.Participants.Remove(licensePlate);

        public Car FindParticipant(string licensePlate) => this.Participants.FirstOrDefault(kvp => kvp.Key == licensePlate).Value;

        public Car GetMostPowerfulCar() => this.Participants.OrderByDescending(kvp => kvp.Value.HorsePower).FirstOrDefault().Value;

        public string Report() 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            foreach (var kvp in this.Participants)
            {
                sb.AppendLine(kvp.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
