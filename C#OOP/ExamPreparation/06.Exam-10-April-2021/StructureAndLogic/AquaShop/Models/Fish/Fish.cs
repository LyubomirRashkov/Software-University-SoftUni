using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities;
using AquaShop.Utilities.Messages;
using System;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private const decimal MinPrice = 0;

        private string name;
        private string species;
        private int size;
        private decimal price;

        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowsExceptionWhenParameterIsNullEmptyOrWhiteSpace(value, ExceptionMessages.InvalidFishName);

                this.name = value;
            }
        }

        public string Species
        {
            get => this.species;
            private set
            {
                Validator.ThrowsExceptionWhenParameterIsNullEmptyOrWhiteSpace(value, ExceptionMessages.InvalidFishSpecies);

                this.species = value;   
            }
        }

        public int Size
        {
            get => this.size;
            protected set
            {
                this.size = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set 
            {
                if (value <= MinPrice)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }

                this.price = value;
            }
        }

        public abstract void Eat();
    }
}
