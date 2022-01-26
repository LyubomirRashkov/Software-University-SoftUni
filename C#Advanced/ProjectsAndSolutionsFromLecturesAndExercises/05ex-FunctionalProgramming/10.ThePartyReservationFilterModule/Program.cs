using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

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
                string condition = commandParts[1];
                string parameter = commandParts[2];

                string key = condition + parameter;

                Predicate<string> predicate = GetPredicate(condition, parameter);

                if (command == "Add filter")
                {
                    filters.Add(key, predicate);
                }
                else if (command == "Remove filter")
                {
                    filters.Remove(key);
                }
            }

            foreach (var kvp in filters)
            {
                guests = guests
                    .Where(x => !kvp.Value(x))
                    .ToList();
            }

            Console.WriteLine(string.Join(' ', guests));
        }

        private static Predicate<string> GetPredicate(string condition, string parameter)
        {
            if (condition == "Starts with")
            {
                return str => str.StartsWith(parameter);
            }
            else if (condition == "Ends with")
            {
                return str => str.EndsWith(parameter);
            }
            else if (condition == "Length")
            {
                return str => str.Length == int.Parse(parameter);
            }
            else if (condition == "Contains")
            {
                return str => str.Contains(parameter);
            }

            return str => true;
        }
    }
}
