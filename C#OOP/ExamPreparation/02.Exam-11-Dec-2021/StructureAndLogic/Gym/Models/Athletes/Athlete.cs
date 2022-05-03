using Gym.Models.Athletes.Contracts;
using Gym.Utilities;
using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private const int MinNumberOfMedals = 0;
        private const int MaxStamina = 100;

        private string fullName;
        private string motivation;
        private int stamina;
        private int numberOfMedals;

        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.NumberOfMedals = numberOfMedals;
            this.Stamina = stamina;
        }

        public string FullName 
        {
            get => this.fullName;
            private set
            {
                Validator.ThrowsExceptionWhenParameterIsNullOrEmpty(value, ExceptionMessages.InvalidAthleteName);

                this.fullName = value;
            }
        }

        public string Motivation
        {
            get => this.motivation;
            private set 
            {
                Validator.ThrowsExceptionWhenParameterIsNullOrEmpty(value, ExceptionMessages.InvalidAthleteMotivation);

                this.motivation = value;
            }
        }

        public int Stamina
        {
            get => this.stamina;
            protected set
            {
                if (value > MaxStamina)
                {
                    this.stamina = MaxStamina;

                    throw new ArgumentException(ExceptionMessages.InvalidStamina);
                }

                this.stamina = value;
            }
        }

        public int NumberOfMedals
        {
            get => this.numberOfMedals;
            private set
            {
                if (value < MinNumberOfMedals)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }

                this.numberOfMedals = value;
            }
        }
        public abstract void Exercise();
    }
}
