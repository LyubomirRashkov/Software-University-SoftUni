using System;
using System.Collections.Generic;

namespace _05.RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputLines = int.Parse(Console.ReadLine());

            HashSet<string> uniqueNames = new HashSet<string>();

            for (int i = 0; i < numberOfInputLines; i++)
            {
                string name = Console.ReadLine();

                uniqueNames.Add(name);
            }

            foreach (string name in uniqueNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
