namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirConditionerFuelConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption, AirConditionerFuelConsumption)
        {
        }

        public override void Refuel(double fuelAmount)
        {
            fuelAmount *= 0.95;

            base.Refuel(fuelAmount);
        }
    }
}
