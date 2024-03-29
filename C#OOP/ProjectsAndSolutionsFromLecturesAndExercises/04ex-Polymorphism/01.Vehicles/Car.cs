﻿namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private const double AirConditionerFuelConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption, AirConditionerFuelConsumption)
        {
        }
    }
}
