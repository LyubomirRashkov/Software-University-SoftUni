using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Utilities;
using SpaceStation.Utilities.Messages;
using System.Collections.Generic;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private string[] items;

        public Planet(string name, params string[] items)
        {
            this.Name = name;

            this.items = items;
        }

        public string Name
        {
            get => this.name;
            private set 
            {
                Validator.ThrowsExceptionWhenParameterIsNullOrWhiteSpace(value, ExceptionMessages.InvalidPlanetName);

                this.name = value;
            }
        }

        public ICollection<string> Items => this.items;
    }
}
