using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parts[0] == "Add")
                {
                    numbers.Add(int.Parse(parts[1]));
                }
                else if (parts[0] == "Remove")
                {
                    numbers.Remove(int.Parse(parts[1]));
                }
                else if (parts[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(parts[1]));
                }
                else if (parts[0] == "Insert")
                {
                    numbers.Insert(int.Parse(parts[2]), int.Parse(parts[1]));
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
