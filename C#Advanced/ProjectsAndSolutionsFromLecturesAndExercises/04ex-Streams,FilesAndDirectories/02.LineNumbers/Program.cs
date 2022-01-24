using System;
using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"..\..\..\..\Resources\text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                int letterCount = lines[i].Count(symbol => char.IsLetter(symbol));

                int punctuationCount = lines[i].Count(symbol => char.IsPunctuation(symbol));

                string newLine = $"Line {i + 1}: {lines[i]} ({letterCount})({punctuationCount})\n";

                File.AppendAllText(@"..\..\..\..\Outputs\02.LineNumbersOutput.txt", newLine);
            }
        }
    }
}
