using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader(@"..\..\..\..\Resources-Inputs\01. Odd Lines\Input.txt"))
            {
                using (StreamWriter sw = new StreamWriter(@"..\..\..\..\Results-Outputs\01.OddLinesOutput.txt"))
                {
                    int rowNumber = 0;

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        if (rowNumber % 2 == 1)
                        {
                            sw.WriteLine(line);
                        }

                        rowNumber++;
                    }
                }
            }
        }
    }
}
