using System;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex emojiRegex = new Regex(@"([:]{2}|[*]{2})(?<emoji>[A-Z][a-z]{2,})(\1)");

            MatchCollection emojiMatches = emojiRegex.Matches(text);

            Regex digitsRegex = new Regex(@"\d");

            MatchCollection digitsMatches = digitsRegex.Matches(text);

            long coolThreshold = 1;

            foreach (Match match in digitsMatches)
            {
                coolThreshold *= int.Parse(match.Value);
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");

            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");

            foreach (Match match in emojiMatches)
            {
                string currentEmoji = match.Groups["emoji"].Value;

                int coolness = 0;

                foreach (char symbol in currentEmoji)
                {
                    coolness += symbol;
                }

                if (coolness > coolThreshold)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
