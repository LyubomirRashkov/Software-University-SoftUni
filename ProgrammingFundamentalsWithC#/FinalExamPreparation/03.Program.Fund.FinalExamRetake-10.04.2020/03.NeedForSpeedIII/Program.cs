using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    public class Car
    {
        public string Model { get; set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }

        public override string ToString()
        {
            return $"{Model} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>(numberOfCars);

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                int mileage = int.Parse(carInfo[1]);
                int fuel = int.Parse(carInfo[2]);

                Car car = new Car
                {
                    Model = model,
                    Mileage = mileage,
                    Fuel = fuel
                };

                cars.Add(car);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Stop")
                {
                    break;
                }

                string[] commandParts = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string currentCommand = commandParts[0];
                string model = commandParts[1];

                Car requiredCar = GetCarByIndex(cars, model);

                if (currentCommand == "Drive")
                {
                    int distance = int.Parse(commandParts[2]);
                    int fuel = int.Parse(commandParts[3]);

                    if (requiredCar.Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        requiredCar.Mileage += distance;
                        requiredCar.Fuel -= fuel;

                        Console.WriteLine($"{requiredCar.Model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                        if (requiredCar.Mileage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {requiredCar.Model}!");

                            cars.Remove(requiredCar);
                        }
                    }
                }
                else if (currentCommand == "Refuel")
                {
                    int fuel = int.Parse(commandParts[2]);

                    int temp = requiredCar.Fuel;
                    requiredCar.Fuel += fuel;

                    if (requiredCar.Fuel > 75)
                    {
                        requiredCar.Fuel = 75;
                    }

                    Console.WriteLine($"{requiredCar.Model} refueled with {requiredCar.Fuel - temp} liters");
                }
                else if (currentCommand == "Revert")
                {
                    int kilometers = int.Parse(commandParts[2]);

                    requiredCar.Mileage -= kilometers;

                    if (requiredCar.Mileage < 10000)
                    {
                        requiredCar.Mileage = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{requiredCar.Model} mileage decreased by {kilometers} kilometers");
                    }
                }
            }

            List<Car> sortedCars = cars
                .OrderByDescending(car => car.Mileage)
                .ThenBy(car => car.Model)
                .ToList();

            foreach (Car car in sortedCars)
            {
                Console.WriteLine(car);
            }
        }

        private static Car GetCarByIndex(List<Car> cars, string model)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Model == model)
                {
                    return cars[i];
                }
            }

            return cars[-1];
        }
    }
}
