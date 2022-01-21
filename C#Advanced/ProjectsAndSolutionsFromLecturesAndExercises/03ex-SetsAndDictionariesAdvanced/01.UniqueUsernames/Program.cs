using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputLines = int.Parse(Console.ReadLine());

            HashSet<string> uniqueNames = new HashSet<string>();

            for (int i = 0; i < numberOfInputLines; i++)
            {
                string line = Console.ReadLine();

                uniqueNames.Add(line);
            }

            foreach (string name in uniqueNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
