using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.FuelConsumption = 1.25;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(double kilometers) => this.Fuel -= (this.FuelConsumption * kilometers);
    }
}
