using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private const int MinLength = 5;
        private const bool DefaultCanRace = false;

        private string fullName;
        private bool canRace;
        private IFormulaOneCar car;
        private int numberOfWins;

        public Pilot(string fullName)
        {
            this.FullName = fullName;

            this.CanRace = DefaultCanRace;
            this.NumberOfWins = 0;
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                Validator.ThrowExceptionWhenParameterIsNullWhiteSpaceOrHasLengthLessThanMinLength(value, MinLength, string.Format(ExceptionMessages.InvalidPilot, value));

                this.fullName = value;
            }
        }
         
        public bool CanRace
        {
            get => this.canRace;
            private set
            {
                this.canRace = value;
            }
        }
        
        public IFormulaOneCar Car
        {
            get => this.car;
            private set => this.car = value ?? throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
        }

        public int NumberOfWins
        {
            get => this.numberOfWins;
            private set => this.numberOfWins = value;
        }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
