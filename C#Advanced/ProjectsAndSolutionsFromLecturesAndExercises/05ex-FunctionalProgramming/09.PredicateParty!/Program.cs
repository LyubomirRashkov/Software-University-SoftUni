using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Party!")
                {
                    break;
                }

                string[] commandParts = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Predicate<string> predicate = GetPredicate(commandParts[1], commandParts[2]);

                if (commandParts[0] == "Remove")
                {
                    guests.RemoveAll(predicate);
                }
                else if (commandParts[0] == "Double")
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (predicate(guests[i]))
                        {
                            string specialGuest = guests[i];
                            guests.Insert(i + 1, specialGuest);
                            i++;
                        }
                    }
                }
            }

            if (guests.Count() == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string condition, string parameter)
        {
            if (condition == "StartsWith")
            {
                return str => str.StartsWith(parameter);
            }
            else if (condition == "EndsWith")
            {
                return str => str.EndsWith(parameter);
            }
            else if (condition == "Length")
            {
                return str => str.Length == int.Parse(parameter);
            }

            return str => true;
        }
    }
}
