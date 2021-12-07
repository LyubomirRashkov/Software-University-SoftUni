using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 1)
                {
                    int passengers = int.Parse(parts[0]);

                    for (int i = 0; i < train.Count; i++)
                    {
                        int currentWagon = train[i];

                        if ((currentWagon + passengers) <= maxCapacity)
                        {
                            train[i] += passengers;
                            break;
                        }
                    }
                }
                else
                {
                    train.Add(int.Parse(parts[1]));
                }
            }

            Console.WriteLine(string.Join(" ", train));
        }
    }
}
