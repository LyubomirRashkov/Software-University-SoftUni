using System;
using System.IO;
using System.Linq;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"..\..\..\..\Resources\text.txt");

            using StreamWriter sw = new StreamWriter(@"..\..\..\..\Outputs\01.EvenLinesOutput.txt");

            char[] specialSymbols = new char[] { '-', ',', '.', '!', '?' };

            int rowNumber = 0;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                if (rowNumber % 2 == 1)
                {
                    rowNumber++;
                    continue;
                }

                foreach (char symbol in specialSymbols)
                {
                    line = line.Replace(symbol, '@');
                }

                string[] lineParts = line
                    .Split(' ');

                string reversedLine = string.Join(' ', lineParts.Reverse());

                sw.WriteLine(reversedLine);

                rowNumber++;
            }
        }
    }
}
