using System;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double DefaultFuelAvailable = 65;
        private const double DefaultFuelConsumptionPerRace = 7.5;

        public TunedCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower, DefaultFuelAvailable, DefaultFuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();

            this.HorsePower = (int)Math.Round(this.HorsePower * 0.97);
        }
    }
}
