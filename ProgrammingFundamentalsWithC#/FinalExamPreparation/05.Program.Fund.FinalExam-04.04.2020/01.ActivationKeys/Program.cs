using System;
using System.Text;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Generate")
                {
                    break;
                }

                string[] commandParts = command
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                string currentCommand = commandParts[0];

                if (currentCommand == "Contains")
                {
                    string substring = commandParts[1];

                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (currentCommand == "Flip")
                {
                    string upperOrLower = commandParts[1];
                    int startIndex = int.Parse(commandParts[2]);
                    int endIndex = int.Parse(commandParts[3]);

                    string firstSubstring = activationKey.Substring(0, startIndex);
                    string secondSubstring = activationKey.Substring(endIndex);
                    string mediumSubstring = activationKey.Substring(startIndex, endIndex - startIndex);

                    StringBuilder sb = new StringBuilder();

                    char currentSymbol = '\0';

                    if (upperOrLower == "Upper")
                    {
                        for (int i = 0; i < mediumSubstring.Length; i++)
                        {
                            currentSymbol = char.ToUpper(mediumSubstring[i]);

                            sb.Append(currentSymbol);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < mediumSubstring.Length; i++)
                        {
                            currentSymbol = char.ToLower(mediumSubstring[i]);

                            sb.Append(currentSymbol);
                        }
                    }

                    mediumSubstring = sb.ToString();

                    activationKey = firstSubstring + mediumSubstring + secondSubstring;

                    Console.WriteLine(activationKey);
                }
                else if (currentCommand == "Slice")
                {
                    int startIndex = int.Parse(commandParts[1]);
                    int endIndex = int.Parse(commandParts[2]);

                    string firstSubstring = activationKey.Substring(0, startIndex);
                    string secondSubstring = activationKey.Substring(endIndex);

                    activationKey = firstSubstring + secondSubstring;

                    Console.WriteLine(activationKey);
                }
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
