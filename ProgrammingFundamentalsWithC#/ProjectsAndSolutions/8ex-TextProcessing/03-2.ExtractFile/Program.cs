using System;

namespace _03_2.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pathParts = Console.ReadLine()
              .Split("\\", StringSplitOptions.RemoveEmptyEntries);

            string fileWithExtension = pathParts[pathParts.Length - 1];

            string[] fileParts = fileWithExtension
                .Split(".");

            string fileExtension = fileParts[fileParts.Length - 1];

            string fileName = fileWithExtension.Replace($".{fileExtension}", string.Empty);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
