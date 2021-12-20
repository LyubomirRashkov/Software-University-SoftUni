using System;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder output = new StringBuilder();

            foreach (var symbol in input)
            {
                char newSymbol = (char)(symbol + 3);

                output.Append(newSymbol);
            }

            Console.WriteLine(output);
        }
    }
}
