using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> appearancesByChar = new SortedDictionary<char, int>();

            foreach (char symbol in text)
            {
                if (!appearancesByChar.ContainsKey(symbol))
                {
                    appearancesByChar.Add(symbol, 0);
                }

                appearancesByChar[symbol]++;
            }

            foreach (var kvp in appearancesByChar)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
