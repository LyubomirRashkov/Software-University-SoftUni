using System;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string worldTour = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Travel")
                {
                    break;
                }

                string[] parts = line
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(parts[1]);

                    if (index >= 0 && index < worldTour.Length)
                    {
                        string newPlace = parts[2];

                        worldTour = worldTour.Insert(index, newPlace);
                    }

                    Console.WriteLine(worldTour);
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(parts[1]);
                    int endIndex = int.Parse(parts[2]);

                    if (startIndex >= 0 && endIndex < worldTour.Length)
                    {
                        string temp = worldTour.Substring(endIndex + 1);

                        worldTour = worldTour.Remove(startIndex);
                        worldTour += temp;
                    }

                    Console.WriteLine(worldTour);
                }
                else if (command == "Switch")
                {
                    string oldString = parts[1];
                    string newString = parts[2];

                    if (worldTour.Contains(oldString))
                    {
                        worldTour = worldTour.Replace(oldString, newString);
                    }

                    Console.WriteLine(worldTour);
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {worldTour}");
        }
    }
}
