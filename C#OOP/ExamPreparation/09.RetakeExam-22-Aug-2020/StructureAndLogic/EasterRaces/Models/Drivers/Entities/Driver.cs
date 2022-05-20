using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int MinNameLength = 5;

        private string name;
        private ICar car;
        private int numberOfWins;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set 
            {
                Validator.ThrowExceptionIfParameterIsNullEmptyOrHasLengthLessThanMinimumLength(value, MinNameLength,        
                                                string.Format(ExceptionMessages.InvalidName, value, MinNameLength));

                this.name = value;
            }
        }

        public ICar Car
        {
            get => this.car;
            private set
            {
                this.car = value;
            }
        }

        public int NumberOfWins
        {
            get => this.numberOfWins;
            private set
            {
                this.numberOfWins = value;
            }
        }

        public bool CanParticipate => this.Car != null;

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }

            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
