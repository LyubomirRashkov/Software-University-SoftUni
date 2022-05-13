using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private IDictionary<string, IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new Dictionary<string, IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != nameof(FreshwaterAquarium) && aquariumType != nameof(SaltwaterAquarium))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            IAquarium aquarium = this.CreateAquarium(aquariumType, aquariumName);

            this.aquariums.Add(aquariumName, aquarium);

            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != nameof(Ornament) && decorationType != nameof(Plant))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            IDecoration decoration = this.CreateDecoration(decorationType);

            this.decorations.Add(decoration);

            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != nameof(FreshwaterFish) && fishType != nameof(SaltwaterFish))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            if (fishType == nameof(FreshwaterFish)
                && this.aquariums[aquariumName].GetType().Name != nameof(FreshwaterAquarium))
            {
                return OutputMessages.UnsuitableWater;
            }

            if (fishType == nameof(SaltwaterFish)
                && this.aquariums[aquariumName].GetType().Name != nameof(SaltwaterAquarium))
            {
                return OutputMessages.UnsuitableWater;
            }

            IFish fish = this.CreateFish(fishType, fishName, fishSpecies, price);

            this.aquariums[aquariumName].AddFish(fish);

            return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums[aquariumName];

            decimal fishValue = aquarium.Fish.Sum(f => f.Price);

            decimal decorationValue = aquarium.Decorations.Sum(d => d.Price);

            decimal value = fishValue + decorationValue;

            return String.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string FeedFish(string aquariumName)
        {
            this.aquariums[aquariumName].Feed();

            return String.Format(OutputMessages.FishFed, this.aquariums[aquariumName].Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            this.aquariums[aquariumName].AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var kvp in this.aquariums)
            {
                sb.AppendLine(kvp.Value.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        private IAquarium CreateAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            return aquarium;
        }

        private IDecoration CreateDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else
            {
                decoration = new Plant();
            }

            return decoration;
        }

        private IFish CreateFish(string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            return fish;
        }
    }
}
