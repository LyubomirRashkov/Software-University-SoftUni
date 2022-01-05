using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string locations = Console.ReadLine();

            Regex regex = new Regex(@"([=/])(?<destination>[A-Z]{1}[A-Za-z]{2,})(\1)");

            MatchCollection matches = regex.Matches(locations);

            List<string> destinations = new List<string>(matches.Count);

            int travelPoints = 0;

            foreach (Match match in matches)
            {
                string destination = match.Groups["destination"].Value;
                destinations.Add(destination);
                travelPoints += destination.Length;
            }

            Console.Write("Destinations: ");
            Console.WriteLine(string.Join(", ", destinations));
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
