using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.WildZoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> foodNeededByAnimal = new Dictionary<string, int>();
            Dictionary<string, List<string>> hungryAnimalsByArea = new Dictionary<string, List<string>>();
            Dictionary<string, string> areaByAnimal = new Dictionary<string, string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "EndDay")
                {
                    break;
                }

                string[] lineParts = line
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string command = lineParts[0];
                string commandInfo = lineParts[1];

                if (command == "Add")
                {
                    string[] commandParts = commandInfo
                        .Split('-', StringSplitOptions.RemoveEmptyEntries);

                    string animalName = commandParts[0];
                    int foodNeeded = int.Parse(commandParts[1]);
                    string area = commandParts[2];

                    if (!foodNeededByAnimal.ContainsKey(animalName))
                    {
                        foodNeededByAnimal.Add(animalName, foodNeeded);

                        if (!hungryAnimalsByArea.ContainsKey(area))
                        {
                            hungryAnimalsByArea.Add(area, new List<string>());
                        }

                        hungryAnimalsByArea[area].Add(animalName);
                        areaByAnimal.Add(animalName, area);
                    }
                    else
                    {
                        foodNeededByAnimal[animalName] += foodNeeded;
                    }
                }
                else if (command == "Feed")
                {
                    string[] commandParts = commandInfo
                        .Split('-', StringSplitOptions.RemoveEmptyEntries);

                    string animalName = commandParts[0];
                    int foodGiven = int.Parse(commandParts[1]);

                    if (!foodNeededByAnimal.ContainsKey(animalName))
                    {
                        continue;
                    }

                    foodNeededByAnimal[animalName] -= foodGiven;

                    if (foodNeededByAnimal[animalName] <= 0)
                    {
                        foodNeededByAnimal.Remove(animalName);

                        string temp = areaByAnimal[animalName];
                        areaByAnimal.Remove(animalName);

                        hungryAnimalsByArea[temp].Remove(animalName);

                        Console.WriteLine($"{animalName} was successfully fed");
                    }
                }
            }

            Console.WriteLine("Animals:");

            Dictionary<string, int> sortedFoodNeededByAnimal = foodNeededByAnimal
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in sortedFoodNeededByAnimal)
            {
                Console.WriteLine($" {kvp.Key} -> {kvp.Value}g");
            }

            Console.WriteLine("Areas with hungry animals:");

            Dictionary<string, List<string>> sortedHungryAnimalsByArea = hungryAnimalsByArea
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in sortedHungryAnimalsByArea)
            {
                Console.WriteLine($" {kvp.Key}: {kvp.Value.Count}");
            }
        }
    }
}
