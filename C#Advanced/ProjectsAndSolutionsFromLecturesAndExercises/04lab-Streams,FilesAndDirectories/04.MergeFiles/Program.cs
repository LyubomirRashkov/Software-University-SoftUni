using System;
using System.IO;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr1 = new StreamReader(@"..\..\..\..\Resources-Inputs\04. Merge Files\FileOne.txt");

            using StreamReader sr2 = new StreamReader(@"..\..\..\..\Resources-Inputs\04. Merge Files\FileTwo.txt");

            using StreamWriter sw = new StreamWriter(@"..\..\..\..\Results-Outputs\04.MergeFilesOutput.txt");

            while (!sr1.EndOfStream && !sr2.EndOfStream)
            {
                string lineFromFileOne = sr1.ReadLine();
                string lineFromFileTwo = sr2.ReadLine();

                sw.WriteLine(lineFromFileOne);
                sw.WriteLine(lineFromFileTwo);
            }
        }
    }
}
