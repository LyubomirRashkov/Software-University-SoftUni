using System;

namespace _02.VehiclesExtension
{
    public class Startup
    {
        public static void Main()
        {
            Vehicle car = null;
            Vehicle truck = null;
            Vehicle bus = null;

            for (int i = 0; i < 3; i++)
            {
                string[] vehicleInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string vehicleType = vehicleInfo[0];
                double fuelQuantity = double.Parse(vehicleInfo[1]);
                double fuelConsumption = double.Parse(vehicleInfo[2]);
                double tankCapacity = double.Parse(vehicleInfo[3]);

                if (vehicleType == nameof(Car))
                {
                    car = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                }
                else if (vehicleType == nameof(Truck))
                {
                    truck = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                }
                else if (vehicleType == nameof(Bus))
                {
                    bus = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                }
            }

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = commandInfo[0];
                string vehicleType = commandInfo[1];
                double parameter = double.Parse(commandInfo[2]);

                if (vehicleType == nameof(Car))
                {
                    ProcessCommand(car, command, parameter);
                }
                else if (vehicleType == nameof(Truck))
                {
                    ProcessCommand(truck, command, parameter);
                }
                else if (vehicleType == nameof(Bus))
                {
                    ProcessCommand(bus, command, parameter);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ProcessCommand(Vehicle vehicle, string command, double parameter)
        {
            if (command == "Drive")
            {
                vehicle.Drive(parameter);
            }
            else if (command == "Refuel")
            {
                vehicle.Refuel(parameter);
            }
            else if (command == "DriveEmpty")
            {
                (vehicle as Bus).DriveEmpty(parameter);
            }
        }
    }
}
