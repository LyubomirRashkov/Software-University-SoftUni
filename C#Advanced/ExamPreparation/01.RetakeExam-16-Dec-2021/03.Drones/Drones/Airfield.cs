using System.Collections.Generic;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new Dictionary<string, Drone>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public double LandingStrip { get; private set; }

        public Dictionary<string, Drone> Drones { get; private set; }

        public int Count
        {
            get
            {
                return this.Drones.Count;
            }
        }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range <= 5 || drone.Range >= 15)
            {
                return "Invalid drone.";
            }
            else if (this.Count == this.Capacity)
            {
                return "Airfield is full.";
            }
            else
            {
                if (!this.Drones.ContainsKey(drone.Name))
                {
                    this.Drones.Add(drone.Name, drone);
                }

                return $"Successfully added {drone.Name} to the airfield.";
            }
        }

        public bool RemoveDrone(string name)
        {
            foreach (var kvp in this.Drones)
            {
                if (kvp.Key == name)
                {
                    this.Drones.Remove(kvp.Key);
                    return true;
                }
            }

            //if (this.Drones.Remove(name))
            //{
            //    return true;
            //}

            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int countOfRemovedDrones = 0;

            foreach (var kvp in this.Drones)
            {
                if (kvp.Value.Brand == brand)
                {
                    this.Drones.Remove(kvp.Key);
                    countOfRemovedDrones++;
                }
            }

            return countOfRemovedDrones;
        }

        public Drone FlyDrone(string name)
        {
            Drone returnedDrone = null;

            foreach (var kvp in this.Drones)
            {
                if (kvp.Key == name && kvp.Value.Available == true)
                {
                    kvp.Value.Available = false;
                    returnedDrone = kvp.Value;
                }
            }

            return returnedDrone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> returnedDrones = new List<Drone>();

            foreach (var kvp in this.Drones)
            {
                if (kvp.Value.Range >= range && kvp.Value.Available == true)
                {
                    kvp.Value.Available = false;
                    returnedDrones.Add(kvp.Value);
                }
            }

            return returnedDrones;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var kvp in this.Drones)
            {
                if (kvp.Value.Available == true)
                {
                    sb.AppendLine(kvp.Value.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
