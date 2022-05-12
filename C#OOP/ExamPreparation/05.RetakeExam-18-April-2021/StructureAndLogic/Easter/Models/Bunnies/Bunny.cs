using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private const int MinEnergy = 0;
        private const int RequiredEnergy = 10;

        private string name;
        private int energy;
        private List<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;

            this.dyes = new List<IDye>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowsExceptionWhenParameterIsNullEmptyOrWhiteSpace(value, ExceptionMessages.InvalidBunnyName);

                this.name= value;
            }
        }

        public int Energy
        {
            get => this.energy;
            protected set 
            {
                if (value < MinEnergy)
                {
                    value = MinEnergy;
                }

                this.energy = value;
            }
        }

        public ICollection<IDye> Dyes => this.dyes;

        public void AddDye(IDye dye)
        {
            this.dyes.Add(dye);
        }

        public virtual void Work()
        {
            this.Energy -= RequiredEnergy;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Energy: {this.Energy}");
            sb.Append($"Dyes: {this.Dyes.Where(d => !d.IsFinished()).Count()} not finished");

            return sb.ToString();
        }
    }
}
