using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities;
using CarRacing.Utilities.Messages;
using System;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private const int MinDrivingExperience = 0;
        private const int MaxDrivingExperience = 100;

        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }

        public string Username
        {
            get => this.username;
            private set 
            {
                Validator.ThrowExceptionIfStringIsNullOrWhitespace(value, ExceptionMessages.InvalidRacerName);

                this.username = value;
            }
        }

        public string RacingBehavior
        {
            get => this.racingBehavior;
            private set 
            {
                Validator.ThrowExceptionIfStringIsNullOrWhitespace(value, ExceptionMessages.InvalidRacerBehavior);

                this.racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get => this.drivingExperience;
            protected set
            {
                if (value < MinDrivingExperience || value > MaxDrivingExperience)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }

                this.drivingExperience = value;
            }
        }

        public ICar Car
        {
            get => this.car;
            private set 
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }

                this.car = value;
            }
        }

        public bool IsAvailable() => this.Car.FuelAvailable >= this.Car.FuelConsumptionPerRace;

        public virtual void Race()
        {
            this.Car.Drive();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Driving behavior: {this.RacingBehavior}");
            sb.AppendLine($"--Driving experience: {this.DrivingExperience}");
            sb.Append(this.Car.ToString());

            return sb.ToString();
        }
    }
}
