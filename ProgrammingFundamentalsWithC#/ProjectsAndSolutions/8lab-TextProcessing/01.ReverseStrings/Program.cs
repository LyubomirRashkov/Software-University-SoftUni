using System;
using System.Linq;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string text = line;
                string reversedText = string.Join("", text.Reverse());

                Console.WriteLine($"{text} = {reversedText}");
            }
        }
    }
}
