using System;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private const int MinStat = 0;
        private const int MaxStat = 100;
        private const string NameExceptionMessage = "A name should not be empty.";

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get 
            { 
                return this.name; 
            }

            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(NameExceptionMessage);
                }

                this.name = value; 
            }
        }

        public int Endurance
        {
            get 
            { 
                return this.endurance;
            }

            private set 
            {
                ValidateParameter(value, nameof(this.Endurance));

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get 
            {
                return this.sprint; 
            }

            private set 
            {
                ValidateParameter(value, nameof(this.Sprint));

                this.sprint = value; 
            }
        }

        public int Dribble
        {
            get 
            {
                return this.dribble; 
            }

            private set
            {
                ValidateParameter(value, nameof(this.Dribble));

                this.dribble = value; 
            }
        }

        public int Passing
        {
            get 
            {
                return this.passing; 
            }

            private set 
            {
                ValidateParameter(value, nameof(this.Passing));

                this.passing = value; 
            }
        }

        public int Shooting
        {
            get 
            {
                return this.shooting; 
            }

            private set 
            {
                ValidateParameter(value, nameof(this.Shooting));

                this.shooting = value; 
            }
        }

        public double SkillLevel => ((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0); 

        private void ValidateParameter(int value, string statName)
        {
            if (value < MinStat || value > MaxStat)
            {
                throw new ArgumentException($"{statName} should be between {MinStat} and {MaxStat}.");
            }
        }
    }
}
