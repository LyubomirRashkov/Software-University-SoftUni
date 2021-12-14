using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.VehicleCatalogue
{
    public class Vehicle
    {
        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Horsepower { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] vehicleData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = vehicleData[0];
                string model = vehicleData[1];
                string color = vehicleData[2];
                int horsepower = int.Parse(vehicleData[3]);

                Vehicle vehicle = new Vehicle
                {
                    Type = type,
                    Model = model,
                    Color = color,
                    Horsepower = horsepower
                };

                vehicles.Add(vehicle);
            }

            while (true)
            {
                string line2 = Console.ReadLine();

                if (line2 == "Close the Catalogue")
                {
                    break;
                }

                string model = line2;

                Vehicle currentVehicle = vehicles
                    .FirstOrDefault(x => x.Model == model);

                if (currentVehicle.Type == "car")
                {
                    Console.WriteLine($"Type: Car");
                }
                else
                {
                    Console.WriteLine($"Type: Truck");
                }

                Console.WriteLine($"Model: {currentVehicle.Model}");
                Console.WriteLine($"Color: {currentVehicle.Color}");
                Console.WriteLine($"Horsepower: {currentVehicle.Horsepower}");
            }

            double averageHorsepowerOfTheCars = CalculateAverageHorsepowerByType(vehicles, "car");
            double averageHorespowerOfTheTrucks = CalculateAverageHorsepowerByType(vehicles, "truck");

            Console.WriteLine($"Cars have average horsepower of: {averageHorsepowerOfTheCars:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageHorespowerOfTheTrucks:F2}.");
        }

        private static double CalculateAverageHorsepowerByType(List<Vehicle> vehicles, string type)
        {
            int sumOfHorsepowers = 0;
            int counter = 0;

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.Type == type)
                {
                    sumOfHorsepowers += vehicle.Horsepower;
                    counter++;
                }
            }

            if (counter == 0)
            {
                return 0;
            }

            return (double)sumOfHorsepowers / counter;
        }
    }
}
