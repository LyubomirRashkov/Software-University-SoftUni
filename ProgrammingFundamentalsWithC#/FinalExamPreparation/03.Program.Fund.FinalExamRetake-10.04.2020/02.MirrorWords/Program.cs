using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex regex = new Regex(@"([@#])(?<firstWord>[A-Za-z]{3,})(\1)(\1)(?<secondWord>[A-Za-z]{3,})(\1)");

            MatchCollection matches = regex.Matches(text);

            List<string> mirrorWords = new List<string>();

            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");

                foreach (Match match in matches)
                {
                    string firstWord = match.Groups["firstWord"].Value;
                    string secondWord = match.Groups["secondWord"].Value;
                    string reversedSecondWord = string.Join("", secondWord.Reverse());

                    if (firstWord == reversedSecondWord)
                    {
                        string currentMirrorWords = firstWord + " <=> " + secondWord;
                        mirrorWords.Add(currentMirrorWords);
                    }
                }

                if (mirrorWords.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("The mirror words are:");

                    Console.WriteLine(string.Join(", ", mirrorWords));
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");

                if (mirrorWords.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
            }
        }
    }
}
