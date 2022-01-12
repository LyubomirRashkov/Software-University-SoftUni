using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCarsThatCanPassDuringAGreenLight = int.Parse(Console.ReadLine());

            Queue<string> carsInAQueue = new Queue<string>();

            int numberOfAllPassedCars = 0;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                if (line == "green")
                {
                    int numberOfCarsThatPassDuringOneGreenLight = 0;

                    while (carsInAQueue.Count > 0 && numberOfCarsThatPassDuringOneGreenLight < numberOfCarsThatCanPassDuringAGreenLight)
                    {
                        string carThatHasPassed = carsInAQueue.Dequeue();
                        numberOfCarsThatPassDuringOneGreenLight++;
                        numberOfAllPassedCars++;

                        Console.WriteLine($"{carThatHasPassed} passed!");
                    }
                }
                else
                {
                    string carThatHasCome = line;

                    carsInAQueue.Enqueue(carThatHasCome);
                }
            }

            Console.WriteLine($"{numberOfAllPassedCars} cars passed the crossroads.");
        }
    }
}
