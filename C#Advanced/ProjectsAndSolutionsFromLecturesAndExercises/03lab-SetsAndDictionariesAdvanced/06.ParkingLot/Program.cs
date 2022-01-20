using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carsNumbers = new HashSet<string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] lineParts = line
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string direction = lineParts[0];
                string carNumber = lineParts[1];

                if (direction == "IN")
                {
                    carsNumbers.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    carsNumbers.Remove(carNumber);
                }
            }

            if (carsNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (string carNumber in carsNumbers)
                {
                    Console.WriteLine(carNumber);
                }
            }
        }
    }
}
