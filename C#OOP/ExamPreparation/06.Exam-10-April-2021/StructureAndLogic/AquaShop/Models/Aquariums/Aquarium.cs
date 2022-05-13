using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decorations;
        private IDictionary<string, IFish> fishByName;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.decorations = new List<IDecoration>();
            this.fishByName = new Dictionary<string, IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowsExceptionWhenParameterIsNullEmptyOrWhiteSpace(value, ExceptionMessages.InvalidAquariumName);

                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                this.capacity = value;
            }
        }

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fishByName.Values.ToList();

        public int Comfort => this.Decorations.Sum(d => d.Comfort);

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fishByName.Add(fish.Name, fish);
        }

        public void Feed() => this.Fish.Select(f => new Action(() => f.Eat()));
        //{
            //    foreach (IFish fish in this.Fish)
            //    {
            //        fish.Eat();
            //    }
        //}

        public bool RemoveFish(IFish fish) => this.fishByName.Remove(fish.Name);

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            if (this.Fish.Any())
            {
                sb.AppendLine($"Fish: {string.Join(", ", this.fishByName.Keys)}");
            }
            else
            {
                sb.AppendLine("Fish: none");
            }

            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.Append($"Comfort: {this.Comfort}");

            return sb.ToString();
        }
    }
}
