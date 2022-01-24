using System;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryForZipping = @"..\..\..\..\Resources\06.ZipAndExtract";

            string directoryForZippedFile = @"..\..\..\..\Outputs\06.ZipAndExtract\Zipped";

            string directoryForExtractedFile = @"..\..\..\..\Outputs\06.ZipAndExtract\Extracted";

            ZipFile.CreateFromDirectory(directoryForZipping, directoryForZippedFile + @"\zipfile.zip");

            ZipFile.ExtractToDirectory(directoryForZippedFile + @"\zipfile.zip", directoryForExtractedFile);
        }
    }
}
