using System;

namespace _01.Vehicles
{
    public class Startup
    {
        public static void Main()
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();

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
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
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
        }

        private static Vehicle CreateVehicle()
        {
            string[] vehicleInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = vehicleInfo[0];
            double fuelQuantity = double.Parse(vehicleInfo[1]);
            double fuelConsumption = double.Parse(vehicleInfo[2]);

            Vehicle vehicle = null;

            if (vehicleType == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (vehicleType == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }

            return vehicle;
        }
    }
}
