using System;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantuty;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double airConditionerFuelConsumption)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.AirConditionerFuelConsumption = airConditionerFuelConsumption;
        }

        protected Vehicle(double fuelQuantity, double fuelConsumption, double airConditionerFuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            AirConditionerFuelConsumption = airConditionerFuelConsumption;
        }

        protected double FuelQuantity
        {
            get => this.fuelQuantuty;

            set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantuty = 0;
                }
                else
                {
                    this.fuelQuantuty = value;
                }
            }
        }

        protected double FuelConsumption { get; private set; }

        protected double TankCapacity { get; private set; }

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
            if (fuelAmount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if ((this.FuelQuantity + fuelAmount) > this.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
                }
                else
                {
                    this.FuelQuantity += fuelAmount;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
