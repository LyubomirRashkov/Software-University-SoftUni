using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filesInCurrentDirectory = Directory.GetFiles(".");

            Dictionary<string, Dictionary<string, double>> filesWithSizeByExtension = new Dictionary<string, Dictionary<string, double>>();

            foreach (string file in filesInCurrentDirectory)
            {
                FileInfo fileInfo = new FileInfo(file);

                string fileName = fileInfo.Name;
                string fileExtension = fileInfo.Extension;
                double fileSizeInKB = fileInfo.Length / 1024.0;

                if (!filesWithSizeByExtension.ContainsKey(fileExtension))
                {
                    filesWithSizeByExtension.Add(fileExtension, new Dictionary<string, double>());
                }

                filesWithSizeByExtension[fileExtension].Add(fileName, fileSizeInKB);
            }

            Dictionary<string, Dictionary<string, double>> sortedFilesWithSizeByExtension = filesWithSizeByExtension
                .OrderByDescending(f => f.Value.Count)
                .ThenBy(f => f.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            List<string> outputLines = new List<string>();

            foreach (var kvp in sortedFilesWithSizeByExtension)
            {
                outputLines.Add(kvp.Key);

                foreach (var nestedKVP in kvp.Value.OrderBy(x => x.Value))
                {
                    outputLines.Add($"--{nestedKVP.Key} - {nestedKVP.Value:F3}kb");
                }
            }

            string outputPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";

            File.WriteAllLines(outputPath, outputLines);
        }
    }
}
