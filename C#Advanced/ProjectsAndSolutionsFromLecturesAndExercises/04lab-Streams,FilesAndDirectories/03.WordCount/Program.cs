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
            using StreamReader wordsSR = new StreamReader(@"..\..\..\..\Resources-Inputs\03. Word Count\words.txt");

            string wordsAsText = wordsSR.ReadToEnd();

            string[] words = wordsAsText
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> appearancesByWord = new Dictionary<string, int>();

            foreach (string item in words)
            {
                if (!appearancesByWord.ContainsKey(item))
                {
                    appearancesByWord.Add(item, 0);
                }
            }

            using StreamReader textSR = new StreamReader(@"..\..\..\..\Resources-Inputs\03. Word Count\text.txt");

            while (!textSR.EndOfStream)
            {
                string lineOfWords = textSR.ReadLine();

                foreach (var kvp in appearancesByWord)
                {
                    string pattern = $"(?<=[^A-Za-z]){kvp.Key}(?=[^A-Za-z])";

                    int count = Regex.Matches(lineOfWords, pattern, RegexOptions.IgnoreCase).Count;

                    appearancesByWord[kvp.Key] += count;
                }
            }

            Dictionary<string, int> sortedAppearancesByWord = appearancesByWord
                .OrderByDescending(x => x.Value)
                .ToDictionary(k => k.Key, v => v.Value);

            using StreamWriter sw = new StreamWriter(@"..\..\..\..\Results-Outputs\03.WordCountOutput.txt");

            foreach (var kvp in sortedAppearancesByWord)
            {
                sw.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
