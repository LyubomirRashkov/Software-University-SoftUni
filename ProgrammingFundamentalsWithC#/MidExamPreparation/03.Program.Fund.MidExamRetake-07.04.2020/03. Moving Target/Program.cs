using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int inputIndex = int.Parse(parts[1]);


                if (parts[0] == "Shoot")
                {
                    int power = int.Parse(parts[2]);

                    if (inputIndex < 0 || inputIndex >= targets.Count)
                    {
                        continue;
                    }

                    targets[inputIndex] -= power;

                    if (targets[inputIndex] <= 0)
                    {
                        targets.RemoveAt(inputIndex);
                    }
                }
                else if (parts[0] == "Add")
                {
                    int value = int.Parse(parts[2]);

                    if (inputIndex < 0 || inputIndex >= targets.Count)
                    {
                        Console.WriteLine("Invalid placement!");
                        continue;
                    }

                    targets.Insert(inputIndex, value);

                }
                else if (parts[0] == "Strike")
                {
                    int radius = int.Parse(parts[2]);

                    int startIndex = inputIndex - radius;
                    int endIndex = inputIndex + radius;

                    if (startIndex < 0 || endIndex >= targets.Count)
                    {
                        Console.WriteLine("Strike missed!");
                        continue;
                    }

                    targets.RemoveRange(startIndex, (radius * 2) + 1);
                }
            }

            Console.WriteLine(string.Join("|", targets));
        }
    }
}
