using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach (char letter in input)
            {
                if (letter == ' ')
                {
                    continue;
                }

                if (counts.ContainsKey(letter))
                {
                    counts[letter]++;
                }
                else
                {
                    counts.Add(letter, 1);
                }
            }

            foreach (var kvp in counts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
