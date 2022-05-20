using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int MinModelLength = 4;

        private readonly int minHorsePower;
        private readonly int maxHorsePower;
                
        private string model;
        private int horsePower;
        private double cubicCentimeters;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;

            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model 
        {
            get => this.model;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinModelLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, MinModelLength));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (value < this.minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters
        {
            get => this.cubicCentimeters;
            private set 
            {
                this.cubicCentimeters = value;
            }
        }

        public double CalculateRacePoints(int laps) => this.CubicCentimeters / this.HorsePower * laps;
    }
}
