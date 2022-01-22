using System;
using System.IO;

namespace _05.SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream reader = new FileStream(@"..\..\..\..\Resources-Inputs\05. Slice File\sliceMe.txt", FileMode.Open);

            int bytesPerFile = (int)Math.Ceiling(reader.Length / 4.0);

            for (int i = 1; i < 5; i++)
            {
                byte[] buffer = new byte[bytesPerFile];

                reader.Read(buffer);

                using FileStream writer = new FileStream(@$"..\..\..\..\Results-Outputs\05.SliceAFileOutput\Part-{i}.txt", FileMode.Create);

                writer.Write(buffer);
            }
        }
    }
}
