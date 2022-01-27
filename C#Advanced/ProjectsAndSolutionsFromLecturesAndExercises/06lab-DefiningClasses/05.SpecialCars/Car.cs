﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year) 
            : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) 
            : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, List<Tire> tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tires = tires;

            foreach (Tire tire in tires)
            {
                SumOfTiresPressure += tire.Pressure;
            }
        }

        private string make;

        private string model;

        private int year;

        private double fuelQuantity;

        private double fuelConsumption;

        private Engine engine;

        private List<Tire> tires;

        private double sumOfTiresPressure;

        public string Make
        {
            get
            {
                return make;
            }
            set
            {
                make = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get
            {
                return fuelConsumption;
            }
            set
            {
                fuelConsumption = value;
            }
        }

        public Engine Engine 
        {
            get 
            {
                return engine;
            }
            set 
            {
                engine = value;
            } 
        }

        public List<Tire> Tires 
        {
            get 
            {
                return tires;
            } 
            set 
            {
                tires = value;
            } 
        }

        public double SumOfTiresPressure 
        { 
            get 
            {
                return sumOfTiresPressure;
            }
            set 
            {
                sumOfTiresPressure = value;
            }
        }

        public void Drive()
        {
            if (fuelQuantity - (0.2 * fuelConsumption) > 0)
            {
                fuelQuantity -= (0.2 * fuelConsumption);
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Make: {this.make}");
            sb.AppendLine($"Model: {this.model}");
            sb.AppendLine($"Year: {this.year}");
            sb.AppendLine($"HorsePowers: {this.engine.HorsePower}");
            sb.Append($"FuelQuantity: {this.fuelQuantity}");

            return sb.ToString();
        }
    }
}
