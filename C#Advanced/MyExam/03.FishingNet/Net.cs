using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.FishingNet
{
    public class Net
    {
        private List<Fish> fish;

        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;

            this.fish = new List<Fish>();
        }

        public string Material { get; private set; }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<Fish> Fish => this.fish.AsReadOnly();

        public int Count => this.Fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType)
                || fish.Length <= 0
                || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (this.Count == this.Capacity)
            {
                return "Fishing net is full.";
            }

            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            for (int i = 0; i < this.fish.Count; i++)
            {
                if (this.fish[i].Weight == weight)
                {
                    this.fish.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public Fish GetFish(string fishType) => this.fish.FirstOrDefault(f => f.FishType == fishType);

        public Fish GetBiggestFish() => this.fish.OrderByDescending(f => f.Length).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {this.Material}:");

            foreach (Fish fish in this.fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
