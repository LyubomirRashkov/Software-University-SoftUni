using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_2.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .ToList();

            List<string> filters = new List<string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Print")
                {
                    break;
                }

                string[] commandParts = line
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                string command = commandParts[0];

                string filter = commandParts[1] + '-' + commandParts[2];

                if (command == "Add filter")
                {
                    filters.Add(filter);
                }
                else if (command == "Remove filter")
                {
                    filters.Remove(filter);
                }
            }

            foreach (string filter in filters)
            {
                string[] filterParts = filter
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

                string condition = filterParts[0];
                string parameter = filterParts[1];

                if (condition == "Starts with")
                {
                    guests = guests
                        .Where(g => !g.StartsWith(parameter))
                        .ToList();
                }
                else if (condition == "Ends with")
                {
                    guests = guests
                        .Where(g => !g.EndsWith(parameter))
                        .ToList();
                }
                else if (condition == "Length")
                {
                    guests = guests
                        .Where(g => g.Length != int.Parse(parameter))
                        .ToList();
                }
                else if (condition == "Contains")
                {
                    guests = guests
                        .Where(g => !g.Contains(parameter))
                        .ToList();
                }
            }

            Console.WriteLine(string.Join(' ', guests));
        }
    }
}
