using DIFrameworks.Interfaces;
using System;

namespace DIFrameworks.Models
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
