using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities;
using CarRacing.Utilities.Messages;
using System;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private const int VINLength = 17;
        private const int MinHorsePower = 0;
        private const double MinFuelAvailable = 0;
        private const double MinFuelConsumptionPerRace = 0;

        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        protected Car(string make, string model, string VIN, int horsePower, double fuelAvailable,
                      double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = VIN;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make 
        {
            get => this.make;
            private set 
            {
                Validator.ThrowExceptionIfStringIsNullOrWhitespace(value, ExceptionMessages.InvalidCarMake);

                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;
            private set 
            {
                Validator.ThrowExceptionIfStringIsNullOrWhitespace(value, ExceptionMessages.InvalidCarModel);

                this.model = value;
            }
        }

        public string VIN
        {
            get => this.vin;
            private set
            {
                if (value.Length != VINLength)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }

                this.vin = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                Validator.ThrowExceptionIfParameterIsBelowBoundary
                                (value, MinHorsePower, ExceptionMessages.InvalidCarHorsePower);

                this.horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get => this.fuelAvailable;
            private set
            {
                if (value < MinFuelAvailable)
                {
                    value = MinFuelAvailable;
                }

                this.fuelAvailable = value;
            }
        }

        public double FuelConsumptionPerRace
        {
            get => this.fuelConsumptionPerRace;
            private set 
            {
                Validator.ThrowExceptionIfParameterIsBelowBoundary
                                (value, MinFuelConsumptionPerRace, ExceptionMessages.InvalidCarFuelConsumption);

                this.fuelConsumptionPerRace = value;
            }
        }

        public virtual void Drive()
        {
            this.FuelAvailable -= this.FuelConsumptionPerRace;
        }

        public override string ToString()
        {
            return $"--Car: {this.Make} {this.Model} ({this.VIN})";
        }
    }
}
