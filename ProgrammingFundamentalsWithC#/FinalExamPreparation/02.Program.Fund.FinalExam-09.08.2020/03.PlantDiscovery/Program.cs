using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    public class Plant
    {
        public Plant()
        {
            Rating = new List<double>();
        }

        public string Name { get; set; }

        public int Rarity { get; set; }

        public List<double> Rating { get; set; }

        public double AverageRating { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlants = int.Parse(Console.ReadLine());

            List<Plant> plants = new List<Plant>(numberOfPlants);

            List<string> plantsNames = new List<string>(numberOfPlants);

            for (int i = 0; i < numberOfPlants; i++)
            {
                string[] plantInfo = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string plantName = plantInfo[0];
                int plantRarity = int.Parse(plantInfo[1]);

                Plant plant = new Plant
                {
                    Name = plantName,
                    Rarity = plantRarity
                };

                if (!plantsNames.Contains(plantName))
                {
                    plants.Add(plant);
                    plantsNames.Add(plantName);
                }
                else
                {
                    foreach (Plant item in plants)
                    {
                        if (plant.Name == plantName)
                        {
                            plant.Rarity = plantRarity;
                            break;
                        }
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Exhibition")
                {
                    break;
                }

                string[] commandParts = command
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string currentCommand = commandParts[0];
                string commandInfo = commandParts[1];

                if (currentCommand == "Rate")
                {
                    string[] infoParts = commandInfo
                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    string infoPlant = infoParts[0];
                    int infoRating = int.Parse(infoParts[1]);

                    if (!IsNameValid(plantsNames, infoPlant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    foreach (Plant item in plants)
                    {
                        if (item.Name == infoPlant)
                        {
                            item.Rating.Add(infoRating);
                            break;
                        }
                    }
                }
                else if (currentCommand == "Update")
                {
                    string[] infoParts = commandInfo
                       .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    string infoPlant = infoParts[0];
                    int infoRarity = int.Parse(infoParts[1]);

                    if (!IsNameValid(plantsNames, infoPlant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    foreach (Plant item in plants)
                    {
                        if (item.Name == infoPlant)
                        {
                            item.Rarity = infoRarity;
                            break;
                        }
                    }
                }
                else if (currentCommand == "Reset")
                {
                    if (!IsNameValid(plantsNames, commandInfo))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    foreach (Plant item in plants)
                    {
                        if (item.Name == commandInfo)
                        {
                            item.Rating.Clear();
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (Plant item in plants)
            {
                if (item.Rating.Count == 0)
                {
                    item.AverageRating = 0;
                }
                else
                {
                    item.AverageRating = item.Rating.Average();
                }
            }

            List<Plant> sortedPlants = plants
                .OrderByDescending(p => p.Rarity)
                .ThenByDescending(p => p.AverageRating)
                .ToList();

            foreach (Plant item in sortedPlants)
            {
                Console.WriteLine($"- {item.Name}; Rarity: {item.Rarity}; Rating: {item.AverageRating:F2}");
            }
        }

        private static bool IsNameValid(List<string> collection, string element)
        {
            if (collection.Contains(element))
            {
                return true;
            }

            return false;
        }
    }
}
