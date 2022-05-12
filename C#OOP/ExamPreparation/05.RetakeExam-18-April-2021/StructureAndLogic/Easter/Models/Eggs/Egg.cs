using Easter.Models.Eggs.Contracts;
using Easter.Utilities;
using Easter.Utilities.Messages;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private const int MinEnergyRequired = 0;
        private const int RequiredEnergy = 10;

        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this.name;
            private set 
            {
                Validator.ThrowsExceptionWhenParameterIsNullEmptyOrWhiteSpace(value, ExceptionMessages.InvalidEggName);

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set
            {
                if (value < MinEnergyRequired)
                {
                    value = MinEnergyRequired;
                }

                this.energyRequired = value;
            }
        }

        public void GetColored()
        {
            this.EnergyRequired -= RequiredEnergy;
        }

        public bool IsDone() => this.EnergyRequired == MinEnergyRequired;
    }
}
