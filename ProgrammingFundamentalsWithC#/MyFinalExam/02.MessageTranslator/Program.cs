using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MessageTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            Regex regex = new Regex(@"^!(?<command>[A-Z][a-z]{2,})!:\[(?<string>[A-Za-z]{8,})\]$");

            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);

                if (!match.Success)
                {
                    Console.WriteLine("The message is invalid");
                    continue;
                }

                string command = match.Groups["command"].Value;
                string str = match.Groups["string"].Value;

                List<int> numbers = new List<int>();

                for (int j = 0; j < str.Length; j++)
                {
                    int number = (int)str[j];

                    numbers.Add(number);
                }

                Console.Write($"{command}: ");

                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
