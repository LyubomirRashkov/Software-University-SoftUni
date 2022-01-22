using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"..\..\..\..\Resources-Inputs\02. Line Numbers\input.txt");

            using StreamWriter sw = new StreamWriter(@"..\..\..\..\Results-Outputs\02.LineNumbersOutput.txt");

            int rowNumber = 1;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                sw.WriteLine($"{rowNumber}. {line}");

                rowNumber++;
            }
        }
    }
}
