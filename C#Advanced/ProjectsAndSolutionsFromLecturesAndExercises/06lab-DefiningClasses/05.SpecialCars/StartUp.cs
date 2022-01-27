using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<List<Tire>> collectionOfTires = new List<List<Tire>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "No more tires")
                {
                    break;
                }

                string[] tiresInfo = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                List<Tire> tires = new List<Tire>();

                for (int i = 0; i < tiresInfo.Length; i += 2)
                {
                    int year = int.Parse(tiresInfo[i]);
                    double pressure = double.Parse(tiresInfo[i + 1]);

                    Tire tire = new Tire(year, pressure);

                    tires.Add(tire);
                }

                collectionOfTires.Add(tires);
            }

            List<Engine> engines = new List<Engine>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Engines done")
                {
                    break;
                }

                string[] engineInfo = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);

                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Show special")
                {
                    break;
                }

                string[] carInfo = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], collectionOfTires[tiresIndex]);

                cars.Add(car);
            }

            List<Car> specialCars = cars
                .Where(c => c.Year >= 2017 && c.Engine.HorsePower > 330 && c.SumOfTiresPressure >= 9 && c.SumOfTiresPressure <= 10)
                .ToList();

            foreach (Car car in specialCars)
            {
                car.Drive();

                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
