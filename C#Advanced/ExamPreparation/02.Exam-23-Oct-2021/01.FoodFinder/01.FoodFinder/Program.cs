using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] vowelsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            char[] consonantsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            Queue<char> vowels = new Queue<char>(vowelsInput);

            Stack<char> consonants = new Stack<char>(consonantsInput);

            string[] targetWords = new string[] { "pear", "flour", "pork", "olive" };

            Dictionary<string, HashSet<char>> words = new Dictionary<string, HashSet<char>>();

            for (int i = 0; i < targetWords.Length; i++)
            {
                if (!words.ContainsKey(targetWords[i]))
                {
                    words.Add(targetWords[i], new HashSet<char>());
                }
            }

            while (consonants.Count > 0)
            {
                char currentVowel = vowels.Dequeue();
                char currentConsonant = consonants.Pop();

                for (int i = 0; i < targetWords.Length; i++)
                {
                    if (targetWords[i].Contains(currentVowel))
                    {
                        words[targetWords[i]].Add(currentVowel);
                    }

                    if (targetWords[i].Contains(currentConsonant))
                    {
                        words[targetWords[i]].Add(currentConsonant);
                    }
                }

                vowels.Enqueue(currentVowel);
            }

            int foundWordsCount = words
                .Where(w => w.Key.Length == w.Value.Count)
                .Count();

            Console.WriteLine($"Words found: {foundWordsCount}");

            foreach (var kvp in words)
            {
                if (kvp.Key.Length == kvp.Value.Count)
                {
                    Console.WriteLine(kvp.Key);
                }
            }
        }
    }
}
