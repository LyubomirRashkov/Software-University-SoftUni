using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.VehicleCatalogue
{
    public class Truck
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {Weight}kg";
        }
    }

    public class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Horsepower { get; set; }

        public override string ToString()
        {
            return $"{Brand}: { Model} - {Horsepower}hp";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] vehicleData = input
                    .Split("/", StringSplitOptions.RemoveEmptyEntries);

                string type = vehicleData[0];
                string brand = vehicleData[1];
                string model = vehicleData[2];
                int number = int.Parse(vehicleData[3]);

                if (type == "Car")
                {
                    Car car = new Car
                    {
                        Brand = brand,
                        Model = model,
                        Horsepower = number
                    };

                    cars.Add(car);
                }
                else if (type == "Truck")
                {
                    Truck truck = new Truck
                    {
                        Brand = brand,
                        Model = model,
                        Weight = number
                    };

                    trucks.Add(truck);
                }
            }

            List<Car> orderedCars = cars
                .OrderBy(c => c.Brand)
                .ToList();

            List<Truck> orderedTrucks = trucks
                .OrderBy(t => t.Brand)
                .ToList();

            if (cars.Count > 0)
            {
                Console.WriteLine("Cars:");

                foreach (Car car in orderedCars)
                {
                    Console.WriteLine(car);
                }
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");

                foreach (Truck truck in orderedTrucks)
                {
                    Console.WriteLine(truck);
                }
            }
        }
    }
}
