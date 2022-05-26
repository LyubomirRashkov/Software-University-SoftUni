using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private const int MinLength = 5;
        private const int MinNumberOfLaps = 1;
        private const bool DefaultTookPlace = false;

        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private IDictionary<string, IPilot> pilotsByFullName;

        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;

            this.TookPlace = DefaultTookPlace;
            this.pilotsByFullName = new Dictionary<string, IPilot>();
        }

        public string RaceName
        {
            get => this.raceName;
            private set
            {
                Validator.ThrowExceptionWhenParameterIsNullWhiteSpaceOrHasLengthLessThanMinLength(value, MinLength, string.Format(ExceptionMessages.InvalidRaceName, value));

                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => this.numberOfLaps;
            private set
            {
                if (value < MinNumberOfLaps)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                this.numberOfLaps = value;
            }
        }

        public bool TookPlace 
        {
            get => this.tookPlace;
            set => this.tookPlace = value;
        }

        public ICollection<IPilot> Pilots => this.pilotsByFullName.Values.ToList();

        public void AddPilot(IPilot pilot) => this.pilotsByFullName.Add(pilot.FullName, pilot);

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The {this.RaceName} race has:");
            sb.AppendLine($"Participants: {this.Pilots.Count}");
            sb.AppendLine($"Number of laps: {this.NumberOfLaps}");

            if (this.TookPlace)
            {
                sb.Append("Took place: Yes");
            }
            else
            {
                sb.Append("Took place: No");
            }

            return sb.ToString();
        }
    }
}
