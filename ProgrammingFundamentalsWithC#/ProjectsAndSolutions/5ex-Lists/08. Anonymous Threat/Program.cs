using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "3:1")
                {
                    break;
                }

                string[] commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "merge")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    else if (startIndex >= line.Count)
                    {
                        continue;
                    }

                    if (endIndex < 0)
                    {
                        continue;
                    }
                    else if (endIndex >= line.Count)
                    {
                        endIndex = line.Count - 1;
                    }

                    string mergedElements = String.Empty;

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        mergedElements += line[i];
                    }

                    line.RemoveRange(startIndex, (endIndex - startIndex + 1));
                    line.Insert(startIndex, mergedElements);
                }
                else if (commands[0] == "divide")
                {
                    int index = int.Parse(commands[1]);
                    int partitions = int.Parse(commands[2]);

                    string element = line[index];

                    line.RemoveAt(index);

                    int partitionSize = element.Length / partitions;

                    List<string> subelements = new List<string>();

                    for (int i = 0; i < partitions - 1; i++)
                    {
                        string subelement = element.Substring(i * partitionSize, partitionSize);

                        subelements.Add(subelement);
                    }

                    string lastSubstring = element.Substring((partitions - 1) * partitionSize);

                    subelements.Add(lastSubstring);

                    line.InsertRange(index, subelements);
                }
            }

            Console.WriteLine(string.Join(" ", line));
        }
    }
}
