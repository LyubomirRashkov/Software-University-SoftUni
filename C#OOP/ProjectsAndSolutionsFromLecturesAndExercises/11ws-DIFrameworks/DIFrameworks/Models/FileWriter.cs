using DIFrameworks.Interfaces;
using System;
using System.IO;

namespace DIFrameworks.Models
{
    public class FileWriter : IFileWriter
    {
        public void Write(string text)
        {
            File.AppendAllText("../../../log.txt", text + Environment.NewLine);
        }
    }
}
