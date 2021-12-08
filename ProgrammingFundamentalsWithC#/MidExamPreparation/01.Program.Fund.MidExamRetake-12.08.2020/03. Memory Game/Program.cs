using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Memory_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int movesCount = 0;
            bool isWinner = false;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                int[] input = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int firstIndex = input[0];
                int secondIndex = input[1];

                movesCount++;

                string movesToAdd = movesCount.ToString();
                string addition = "-" + $"{movesToAdd}" + "a";

                if (firstIndex == secondIndex
                    || firstIndex < 0
                    || firstIndex >= elements.Count
                    || secondIndex < 0
                    || secondIndex >= elements.Count)
                {
                    elements.Insert(elements.Count / 2, addition);
                    elements.Insert(elements.Count / 2 + 1, addition);

                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    continue;
                }

                if (elements[firstIndex] == elements[secondIndex])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {elements[firstIndex]}!");

                    int smallerIndex = Math.Min(firstIndex, secondIndex);
                    int biggerIndex = Math.Max(firstIndex, secondIndex);

                    elements.RemoveAt(smallerIndex);
                    elements.RemoveAt(biggerIndex - 1);
                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                if (elements.Count == 0)
                {
                    isWinner = true;

                    Console.WriteLine($"You have won in {movesCount} turns!");
                    break;
                }
            }

            if (!isWinner)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", elements));
            }
        }
    }
}
