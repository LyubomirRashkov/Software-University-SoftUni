using DIFrameworks.Interfaces;
using System;

namespace DIFrameworks.Models
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
