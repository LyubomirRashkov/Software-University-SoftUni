using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System.Collections.Generic;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        private readonly IDictionary<string, double> multipliersByRacingBehavior;

        public Map()
        {
            this.multipliersByRacingBehavior = new Dictionary<string, double>
            {
                { "strict", 1.2},
                { "aggressive", 1.1 }
            };
        }

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            racerOne.Race();
            racerTwo.Race();

            IRacer winner = null;

            double chanceOfWinningOfRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience *           
                                               this.multipliersByRacingBehavior[racerOne.RacingBehavior];

            double chanceOfWinningOfRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 
                                               this.multipliersByRacingBehavior[racerTwo.RacingBehavior];

            if (chanceOfWinningOfRacerOne > chanceOfWinningOfRacerTwo)
            {
                winner = racerOne;
            }
            else
            {
                winner = racerTwo;
            }

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
        }
    }
}
