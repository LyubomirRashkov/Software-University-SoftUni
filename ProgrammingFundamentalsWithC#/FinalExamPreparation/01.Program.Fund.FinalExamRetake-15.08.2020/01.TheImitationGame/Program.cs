using System;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Decode")
                {
                    break;
                }

                string[] parts = line
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (command == "Move")
                {
                    int numberOfLetters = int.Parse(parts[1]);

                    string movedChars = message.Substring(0, numberOfLetters);
                    string temp = message.Substring(numberOfLetters);

                    message = temp + movedChars;
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(parts[1]);
                    string value = parts[2];

                    message = message.Insert(index, value);
                }
                else if (command == "ChangeAll")
                {
                    string substring = parts[1];
                    string replacement = parts[2];

                    message = message.Replace(substring, replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
