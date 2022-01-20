using System;
using System.Collections.Generic;

namespace _04.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputLines = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> citiesByCountryAndContinent = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < numberOfInputLines; i++)
            {
                string[] lineParts = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string continent = lineParts[0];
                string country = lineParts[1];
                string city = lineParts[2];

                if (!citiesByCountryAndContinent.ContainsKey(continent))
                {
                    citiesByCountryAndContinent.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!citiesByCountryAndContinent[continent].ContainsKey(country))
                {
                    citiesByCountryAndContinent[continent].Add(country, new List<string>());
                }

                citiesByCountryAndContinent[continent][country].Add(city);
            }

            foreach (var kvp in citiesByCountryAndContinent)
            {
                Console.WriteLine($"{kvp.Key}:");

                foreach (var nestedKVP in kvp.Value)
                {
                    Console.Write($"  {nestedKVP.Key} -> ");

                    Console.WriteLine(string.Join(", ", nestedKVP.Value));
                }
            }
        }
    }
}
