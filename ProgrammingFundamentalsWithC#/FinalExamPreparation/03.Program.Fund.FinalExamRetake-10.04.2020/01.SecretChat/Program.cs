using System;
using System.Linq;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Reveal")
                {
                    break;
                }

                string[] commandParts = line
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                string command = commandParts[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(commandParts[1]);

                    message = message.Insert(index, " ");

                    Console.WriteLine(message);
                }
                else if (command == "Reverse")
                {
                    string substring = commandParts[1];

                    int index = message.IndexOf(substring);

                    if (index == -1)
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        string firstSubstring = message.Substring(0, index);
                        string secondSubstring = message.Substring(index + substring.Length);

                        string reversedSubstring = string.Join("", substring.Reverse());

                        message = firstSubstring + secondSubstring + reversedSubstring;

                        Console.WriteLine(message);
                    }
                }
                else if (command == "ChangeAll")
                {
                    string substring = commandParts[1];
                    string replacement = commandParts[2];

                    message = message.Replace(substring, replacement);

                    Console.WriteLine(message);
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
