using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfEngines = int.Parse(Console.ReadLine());

            Dictionary<string, Engine> enginesByModel = new Dictionary<string, Engine>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = engineInfo[0];

                if (!enginesByModel.ContainsKey(model))
                {
                    int power = int.Parse(engineInfo[1]);

                    Engine engine = new Engine(model, power);

                    if (engineInfo.Length == 3)
                    {
                        bool isSuccessfullyParsed = int.TryParse(engineInfo[2], out int displacement);

                        if (isSuccessfullyParsed)
                        {
                            engine.Displacement = displacement;
                        }
                        else
                        {
                            string efficiency = engineInfo[2];

                            engine.Efficiency = efficiency;
                        }
                    }

                    if (engineInfo.Length == 4)
                    {
                        int displacement = int.Parse(engineInfo[2]);
                        string efficiency = engineInfo[3];

                        engine.Displacement = displacement;
                        engine.Efficiency = efficiency;
                    }

                    enginesByModel.Add(model, engine);
                }
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                string engineModel = carInfo[1];

                Engine engine = enginesByModel[engineModel];

                Car car = new Car(model, engine);

                if (carInfo.Length == 3)
                {
                    bool isSuccessfullyParsed = int.TryParse(carInfo[2], out int weight);

                    if (isSuccessfullyParsed)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        string color = carInfo[2];
                        car.Color = color;
                    }
                }

                if (carInfo.Length == 4)
                {
                    int weight = int.Parse(carInfo[2]);
                    string color = carInfo[3];

                    car.Weight = weight;
                    car.Color = color;
                }

                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
