using System;
using System.Text;

namespace _02.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StringBuilder output = new StringBuilder();

            foreach (string word in input)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    output.Append(word);
                }
            }

            Console.WriteLine(output.ToString());
        }
    }
}
