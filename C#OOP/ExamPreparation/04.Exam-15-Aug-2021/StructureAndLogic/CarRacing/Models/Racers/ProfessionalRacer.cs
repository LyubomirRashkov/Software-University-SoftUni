using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int DefaultDrivingExperience = 30;
        private const string DefaultRacingBehavior = "strict";
        private const int AdditionalDrivingExperience = 10;

        public ProfessionalRacer(string username, ICar car) 
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
