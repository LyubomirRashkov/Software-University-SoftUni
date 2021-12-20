using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder output = new StringBuilder();

            char symbol = '\0';

            for (int i = 0; i < input.Length; i++)
            {
                if (symbol != input[i])
                {
                    output.Append(input[i]);
                    symbol = input[i];
                }
            }

            Console.WriteLine(output);
        }
    }
}
