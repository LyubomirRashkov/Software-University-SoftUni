using System;
using System.Text;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Done")
                {
                    break;
                }

                string[] commandParts = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currentCommand = commandParts[0];

                if (currentCommand == "TakeOdd")
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 == 1)
                        {
                            sb.Append(password[i]);
                        }
                    }

                    password = sb.ToString();

                    Console.WriteLine(password);
                }
                else if (currentCommand == "Cut")
                {
                    int index = int.Parse(commandParts[1]);
                    int length = int.Parse(commandParts[2]);

                    string substring = password.Substring(index, length);

                    int indexToRemove = password.IndexOf(substring);

                    string firstSubstring = password.Substring(0, indexToRemove);
                    string secondSubstring = password.Substring(indexToRemove + length);

                    password = firstSubstring + secondSubstring;

                    Console.WriteLine(password);
                }
                else if (currentCommand == "Substitute")
                {
                    string substring = commandParts[1];

                    if (password.Contains(substring))
                    {
                        string substitute = commandParts[2];
                        password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
