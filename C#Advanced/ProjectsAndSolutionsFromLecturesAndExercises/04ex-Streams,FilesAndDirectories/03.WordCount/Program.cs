using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            string[] words = File.ReadAllLines(@"..\..\..\..\Resources\words.txt");

            string text = File.ReadAllText(@"..\..\..\..\Resources\text.txt");

            foreach (string word in words)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount.Add(word, 0);
                }
            }

            foreach (var kvp in wordsCount)
            {
                string regexPattern = $"(?<=[^A-Za-z]){kvp.Key}(?=[^A-Za-z])";

                Regex regex = new Regex(regexPattern);

                MatchCollection matches = regex.Matches(text.ToLowerInvariant());

                wordsCount[kvp.Key] += matches.Count;

                string outputLine = $"{kvp.Key} - {wordsCount[kvp.Key]}\n";

                File.AppendAllText(@"..\..\..\..\Outputs\03.WordCountActualResults.txt", outputLine);
            }

            Dictionary<string, int> sortedWordsCount = wordsCount
                .OrderByDescending(x => x.Value)
                .ToDictionary(k => k.Key, v => v.Value);

            List<string> kvpsInSortedWordsCount = new List<string>(sortedWordsCount.Count);

            foreach (var kvp in sortedWordsCount)
            {
                string kvpInfo = $"{kvp.Key} - {kvp.Value}";

                kvpsInSortedWordsCount.Add(kvpInfo);
            }

            bool areEquivalent = true;

            string[] actualResultsLines = File.ReadAllLines(@"..\..\..\..\Resources\expectedResult.txt");

            for (int i = 0; i < actualResultsLines.Length; i++)
            {
                if (actualResultsLines[i] != kvpsInSortedWordsCount[i])
                {
                    areEquivalent = false;
                    break;
                }
            }

            if (areEquivalent)
            {
                Console.WriteLine("Sorted results in actualResults.txt are identical with these in expectedResults.txt");
            }
            else
            {
                Console.WriteLine("Sorted results in actualResults.txt are not identical with these in expectedResults.txt");
            }
        }
    }
}
