using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.P_rates
{
    public class City
    {
        public string Name { get; set; }

        public int Population { get; set; }

        public int Gold { get; set; }

        public override string ToString()
        {
            return $"{Name} -> Population: {Population} citizens, Gold: {Gold} kg";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Sail")
                {
                    break;
                }

                string[] townInfo = line
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);

                string cityName = townInfo[0];
                int cityPopulation = int.Parse(townInfo[1]);
                int cityGold = int.Parse(townInfo[2]);

                City city = new City
                {
                    Name = cityName,
                    Population = cityPopulation,
                    Gold = cityGold
                };

                if (cities.Count == 0)
                {
                    cities.Add(city);
                }
                else
                {
                    int indexOfCityInCities = GetIndexOfCityInCities(cities, cityName);

                    if (indexOfCityInCities == -1)
                    {
                        cities.Add(city);
                    }
                    else
                    {
                        cities[indexOfCityInCities].Population += cityPopulation;
                        cities[indexOfCityInCities].Gold += cityGold;
                    }
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] commandInfo = line
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string command = commandInfo[0];
                string requiredCity = commandInfo[1];

                int indexOfRequiredCityInCities = GetIndexOfCityInCities(cities, requiredCity);

                City currentCity = cities[indexOfRequiredCityInCities];

                if (command == "Plunder")
                {
                    int people = int.Parse(commandInfo[2]);
                    int gold = int.Parse(commandInfo[3]);

                    Console.WriteLine($"{currentCity.Name} plundered! {gold} gold stolen, {people} citizens killed.");

                    currentCity.Population -= people;
                    currentCity.Gold -= gold;

                    if (currentCity.Population == 0 || currentCity.Gold == 0)
                    {
                        Console.WriteLine($"{currentCity.Name} has been wiped off the map!");

                        cities.Remove(currentCity);
                    }
                }
                else if (command == "Prosper")
                {
                    int gold = int.Parse(commandInfo[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        currentCity.Gold += gold;

                        Console.WriteLine($"{gold} gold added to the city treasury. {currentCity.Name} now has {currentCity.Gold} gold.");
                    }
                }
            }

            if (cities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                List<City> sortedCities = cities
                    .OrderByDescending(c => c.Gold)
                    .ThenBy(c => c.Name)
                    .ToList();

                Console.WriteLine($"Ahoy, Captain! There are {sortedCities.Count} wealthy settlements to go to:");

                foreach (City city in sortedCities)
                {
                    Console.WriteLine(city);
                }
            }
        }

        private static int GetIndexOfCityInCities(List<City> cities, string cityName)
        {
            for (int i = 0; i < cities.Count; i++)
            {
                if (cities[i].Name == cityName)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
