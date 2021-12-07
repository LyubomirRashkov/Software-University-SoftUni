using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
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

                if (parts.Length == 2)
                {
                    int elementToDelete = int.Parse(parts[1]);

                    numbers.RemoveAll(n => n == elementToDelete);
                }
                else
                {
                    int idxToInsert = int.Parse(parts[2]);
                    int elementToInsert = int.Parse(parts[1]);

                    numbers.Insert(idxToInsert, elementToInsert);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
