using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(@"..\..\..\..\Resources-Inputs\06. Folder Size\TestFolder");

            double size = 0;

            foreach (string file in files)
            {
                long currentFileSize = new FileInfo(file).Length;

                size += currentFileSize;
            }

            size /= 1024;
            size /= 1024;

            string output = size.ToString();

            using StreamWriter sw = new StreamWriter(@"..\..\..\..\Results-Outputs\06.FolderSize.Output.txt");

            sw.WriteLine(output);
        }
    }
}
