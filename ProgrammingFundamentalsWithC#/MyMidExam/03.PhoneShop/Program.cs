using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PhoneShop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] commandParts = line
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandParts[0];

                if (command == "Add")
                {
                    string phone = commandParts[1];

                    if (!phones.Contains(phone))
                    {
                        phones.Add(phone);
                    }
                }
                else if (command == "Remove")
                {
                    string phone = commandParts[1];

                    phones.Remove(phone);
                }
                else if (command == "Bonus phone")
                {
                    string[] secondParts = commandParts[1]
                        .Split(":", StringSplitOptions.RemoveEmptyEntries);

                    string oldPhone = secondParts[0];
                    string newPhone = secondParts[1];

                    int indexOfTheOldPhone = phones.IndexOf(oldPhone);

                    if (indexOfTheOldPhone > -1)
                    {
                        phones.Insert((indexOfTheOldPhone + 1), newPhone);
                    }
                }
                else if (command == "Last")
                {
                    string phone = commandParts[1];

                    if (phones.Remove(phone))
                    {
                        phones.Add(phone);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
