using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberofCommands = int.Parse(Console.ReadLine());

            Dictionary<string, string> plateNumberByUser = new Dictionary<string, string>();

            for (int i = 0; i < numberofCommands; i++)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];
                string user = parts[1];

                if (command == "register")
                {
                    if (plateNumberByUser.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plateNumberByUser[user]}");
                    }
                    else
                    {
                        string licensePlateNumber = parts[2];

                        plateNumberByUser.Add(user, licensePlateNumber);

                        Console.WriteLine($"{user} registered {licensePlateNumber} successfully");
                    }
                }
                else if (command == "unregister")
                {
                    if (plateNumberByUser.Remove(user))
                    {
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                }
            }

            foreach (var kvp in plateNumberByUser)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
