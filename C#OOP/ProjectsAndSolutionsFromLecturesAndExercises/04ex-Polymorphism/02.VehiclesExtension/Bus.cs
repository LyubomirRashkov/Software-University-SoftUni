using System;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double AirConditionerFuelConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, AirConditionerFuelConsumption)
        {
        }

        public void DriveEmpty(double distance)
        {
            double requiredFuel = distance * this.FuelConsumption;

            if (requiredFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= requiredFuel;

                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
    }
}
