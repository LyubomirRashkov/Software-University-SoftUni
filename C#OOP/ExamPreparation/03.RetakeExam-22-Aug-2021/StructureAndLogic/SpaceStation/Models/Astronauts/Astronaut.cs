using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities;
using SpaceStation.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private const double MinOxygen = 0;
        private const double RequiredOxygen = 10;

        private string name;
        private double oxygen;
        private IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;

            this.Bag = new Backpack();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowsExceptionWhenParameterIsNullOrWhiteSpace(value, ExceptionMessages.InvalidAstronautName);

                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < MinOxygen)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > MinOxygen;

        public IBag Bag
        {
            get => this.bag;
            private set
            {
                this.bag = value;
            }
        }

        public virtual void Breath()
        {
            this.Oxygen -= RequiredOxygen;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Oxygen: {this.Oxygen}");

            if (!this.Bag.Items.Any())
            {
                sb.Append("Bag items: none");
            }
            else
            {
                sb.Append($"Bag items: {string.Join(", ", this.Bag.Items)}");
            }

            return sb.ToString();
        }
    }
}
