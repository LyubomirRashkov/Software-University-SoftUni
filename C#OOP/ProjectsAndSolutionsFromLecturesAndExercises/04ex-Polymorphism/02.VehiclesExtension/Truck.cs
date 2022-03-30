using System;

namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double AirConditionerFuelConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, AirConditionerFuelConsumption)
        {
        }

        public override void Refuel(double fuelAmount)
        {
            if ((this.FuelQuantity + fuelAmount) > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
            }
            else
            {
                fuelAmount *= 0.95;

                base.Refuel(fuelAmount);
            }
        }
    }
}
