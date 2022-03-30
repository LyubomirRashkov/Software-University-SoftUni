using System;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double airConditionerFuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.AirConditionerFuelConsumption = airConditionerFuelConsumption;
        }

        private double FuelQuantity { get; set; }

        private double FuelConsumption { get; set; }

        private double AirConditionerFuelConsumption { get; set; }

        public void Drive(double distance) 
        {
            double requiredFuel = distance * (this.FuelConsumption + this.AirConditionerFuelConsumption);

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

        public virtual void Refuel(double fuelAmount) 
        {
            this.FuelQuantity += fuelAmount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
