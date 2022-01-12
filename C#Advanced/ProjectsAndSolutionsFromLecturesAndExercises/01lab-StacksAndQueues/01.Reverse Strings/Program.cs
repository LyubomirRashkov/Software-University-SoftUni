using System;
using System.Collections.Generic;

namespace _01.Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> symbolsInInput = new Stack<char>(input.Length);

            foreach (char symbol in input)
            {
                symbolsInInput.Push(symbol);
            }

            while (symbolsInInput.Count > 0)
            {
                Console.Write(symbolsInInput.Pop());
            }

            Console.WriteLine();
        }
    }
}
