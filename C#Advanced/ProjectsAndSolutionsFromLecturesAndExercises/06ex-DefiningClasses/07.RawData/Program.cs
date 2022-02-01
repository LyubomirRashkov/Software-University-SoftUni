using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>(numberOfCars);

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];

                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);

                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                Cargo cargo = new Cargo(cargoType, cargoWeight);

                List<Tire> tires = new List<Tire>(4);

                for (int j = 0; j < 7; j += 2)
                {
                    double tirePressure = double.Parse(carInfo[5 + j]);
                    int tireAge = int.Parse(carInfo[6 + j]);

                    Tire tire = new Tire(tireAge, tirePressure);

                    tires.Add(tire);
                }

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            List<Car> filteredCars = new List<Car>();

            string targetCargoType = Console.ReadLine();

            if (targetCargoType == "fragile")
            {
                filteredCars = cars
                    .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                    .ToList();
            }
            else
            {
                filteredCars = cars
                    .Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)
                    .ToList();
            }

            foreach (Car car in filteredCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
