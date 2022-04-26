using System;
using System.Collections.Generic;
using System.IO;

namespace _01.SingletonPattern
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private static SingletonDataContainer instance = new SingletonDataContainer();

        private Dictionary<string, int> populationByCountry;

        private SingletonDataContainer()
        {
            this.populationByCountry = new Dictionary<string, int>();

            Console.WriteLine("Initializing singleton object.");

            string[] elements = File.ReadAllLines("../../../Top10CountriesWithTheirPopulation.txt");

            foreach (string element in elements)
            {
                string[] elementParts = element.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string country = elementParts[0];
                int population = int.Parse(elementParts[1]);

                this.populationByCountry.Add(country, population);
            }
        }

        public static SingletonDataContainer Instance => instance;

        public int GetPopulation(string name)
        {
            return this.populationByCountry[name];
        }
    }
}
