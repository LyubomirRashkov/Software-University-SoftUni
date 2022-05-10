using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int DefaultDrivingExperience = 10;
        private const string DefaultRacingBehavior = "aggressive";
        private const int AdditionalDrivingExperience = 5;

        public StreetRacer(string username, ICar car) 
            : base(username, DefaultRacingBehavior, DefaultDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();

            this.DrivingExperience += AdditionalDrivingExperience;
        }
    }
}
