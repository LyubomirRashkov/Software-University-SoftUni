using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CoffeeLover
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> coffees = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] partsOfTheCommand = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = partsOfTheCommand[0];

                if (action == "Include")
                {
                    string coffee = partsOfTheCommand[1];
                    coffees.Add(coffee);
                }
                else if (action == "Remove")
                {
                    string position = partsOfTheCommand[1];
                    int numberOfCoffees = int.Parse(partsOfTheCommand[2]);

                    if (numberOfCoffees > coffees.Count)
                    {
                        continue;
                    }

                    if (position == "first")
                    {
                        coffees.RemoveRange(0, numberOfCoffees);
                    }
                    else
                    {
                        coffees.RemoveRange((coffees.Count - numberOfCoffees), numberOfCoffees);
                    }
                }
                else if (action == "Prefer")
                {
                    int firstIndex = int.Parse(partsOfTheCommand[1]);
                    int secondIndex = int.Parse(partsOfTheCommand[2]);

                    int first = Math.Min(firstIndex, secondIndex);
                    int second = Math.Max(firstIndex, secondIndex);

                    if (first >= 0 && second < coffees.Count)
                    {
                        string temp = coffees[first];
                        coffees[first] = coffees[second];
                        coffees[second] = temp;
                    }
                }
                else if (action == "Reverse")
                {
                    coffees.Reverse();
                }
            }

            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(" ", coffees));
        }
    }
}
