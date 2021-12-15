using System;
using System.Collections.Generic;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> appearancesCount = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string wordInLowerCase = word.ToLower();

                if (appearancesCount.ContainsKey(wordInLowerCase))
                {
                    appearancesCount[wordInLowerCase]++;
                }
                else
                {
                    appearancesCount.Add(wordInLowerCase, 1);
                }
            }

            foreach (var kvp in appearancesCount)
            {
                if (kvp.Value % 2 != 0)
                {
                    Console.Write(kvp.Key + " ");
                }
            }
        }
    }
}
