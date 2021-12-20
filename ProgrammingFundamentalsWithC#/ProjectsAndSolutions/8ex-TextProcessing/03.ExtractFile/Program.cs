using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pathParts = Console.ReadLine()
                .Split("\\", StringSplitOptions.RemoveEmptyEntries);

            string fileWithExtension = pathParts[pathParts.Length - 1];

            int index = fileWithExtension.LastIndexOf('.');

            string filename = fileWithExtension.Substring(0, index);
            string extension = fileWithExtension.Substring(index + 1);

            Console.WriteLine($"File name: {filename}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
