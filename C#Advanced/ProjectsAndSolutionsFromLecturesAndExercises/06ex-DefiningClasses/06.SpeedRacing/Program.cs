using System;
using System.Collections.Generic;

namespace _06.SpeedRacing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Car> carsByModel = new Dictionary<string, Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);

                if (!carsByModel.ContainsKey(model))
                {
                    Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);

                    carsByModel.Add(model, car);
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] commandInfo = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = commandInfo[1];
                double distance = double.Parse(commandInfo[2]);

                Car wantedCar = carsByModel[model];
                wantedCar.Drive(distance);
            }

            foreach (var kvp in carsByModel)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value.FuelAmount:F2} {kvp.Value.TravelledDistance}");
            }
        }
    }
}
