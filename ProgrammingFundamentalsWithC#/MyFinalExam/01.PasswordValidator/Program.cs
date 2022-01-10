using System;
using System.Text;

namespace _01.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Complete")
                {
                    break;
                }

                string[] lineParts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = lineParts[0];

                if (command == "Make")
                {
                    string target = lineParts[1];

                    int index = int.Parse(lineParts[2]);

                    if (index < 0 || index >= password.Length)
                    {
                        continue;
                    }

                    StringBuilder sb = new StringBuilder();

                    if (target == "Upper")
                    {
                        for (int i = 0; i < password.Length; i++)
                        {
                            char currentSymbol = password[i];

                            if (i == index)
                            {
                                currentSymbol = char.ToUpper(password[i]);
                            }

                            sb.Append(currentSymbol);
                        }

                        password = sb.ToString();

                        Console.WriteLine(password);
                    }
                    else
                    {
                        for (int i = 0; i < password.Length; i++)
                        {
                            char currentSymbol = password[i];

                            if (i == index)
                            {
                                currentSymbol = char.ToLower(password[i]);
                            }

                            sb.Append(currentSymbol);
                        }

                        password = sb.ToString();

                        Console.WriteLine(password);
                    }
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(lineParts[1]);
                    string symbol = lineParts[2];

                    if (index < 0 || index >= password.Length)
                    {
                        continue;
                    }

                    password = password.Insert(index, symbol);

                    Console.WriteLine(password);
                }
                else if (command == "Replace")
                {
                    char symbol = char.Parse(lineParts[1]);
                    int value = int.Parse(lineParts[2]);

                    if (!password.Contains(symbol))
                    {
                        continue;
                    }

                    char result = (char)(symbol + value);

                    password = password.Replace(symbol, result);

                    Console.WriteLine(password);
                }
                else if (command == "Validation")
                {
                    if (password.Length < 8)
                    {
                        Console.WriteLine("Password must be at least 8 characters long!");
                    }

                    if (IsThereInvalidSymbol(password))
                    {
                        Console.WriteLine("Password must consist only of letters, digits and _!");
                    }

                    if (!IsThereUppercaseLetters(password))
                    {
                        Console.WriteLine("Password must consist at least one uppercase letter!");
                    }

                    if (!IsThereLowercaseLetters(password))
                    {
                        Console.WriteLine("Password must consist at least one lowercase letter!");
                    }

                    if (!IsThereDigits(password))
                    {
                        Console.WriteLine("Password must consist at least one digit!");
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        private static bool IsThereDigits(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                char symbol = password[i];

                if (char.IsDigit(symbol))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsThereLowercaseLetters(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                char symbol = password[i];

                if (char.IsLower(symbol))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsThereUppercaseLetters(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                char symbol = password[i];

                if (char.IsUpper(symbol))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsThereInvalidSymbol(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                char symbol = password[i];

                if (!char.IsLetterOrDigit(symbol) && symbol != '_')
                {
                    return true;
                }
            }

            return false;
        }
    }
}
