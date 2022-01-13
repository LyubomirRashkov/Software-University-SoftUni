using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int durationOfTheGreenLight = int.Parse(Console.ReadLine());
            int durationOfTheFreeWindow = int.Parse(Console.ReadLine());

            Queue<string> queueOfCars = new Queue<string>();

            int passedCarsCount = 0;

            bool isThereAnAccident = false;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                if (line != "green")
                {
                    queueOfCars.Enqueue(line);
                }
                else
                {
                    int currentGreenLight = durationOfTheGreenLight;

                    while (currentGreenLight > 0 && queueOfCars.Count > 0)
                    {
                        string passingCar = queueOfCars.Peek();

                        if (passingCar.Length <= currentGreenLight)
                        {
                            queueOfCars.Dequeue();
                            currentGreenLight -= passingCar.Length;
                            passedCarsCount++;
                        }
                        else if (passingCar.Length <= currentGreenLight + durationOfTheFreeWindow)
                        {
                            queueOfCars.Dequeue();
                            currentGreenLight = 0;
                            passedCarsCount++;
                        }
                        else
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{passingCar} was hit at {passingCar[currentGreenLight + durationOfTheFreeWindow]}.");
                            isThereAnAccident = true;
                            break;
                        }
                    }

                    if (isThereAnAccident)
                    {
                        break;
                    }
                }
            }

            if (!isThereAnAccident)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCarsCount} total cars passed the crossroads.");
            }
        }
    }
}
