using System;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var username in usernames)
            {
                if (IsValid(username))
                {
                    Console.WriteLine(username);
                }
            }
        }

        private static bool IsValid(string username)
        {
            if (!HasValidLength(username, 3, 16))
            {
                return false;
            }

            if (!ContainsOnlyAllowedCharacters(username))
            {
                return false;
            }

            return true;
        }

        private static bool ContainsOnlyAllowedCharacters(string username)
        {
            foreach (var symbol in username)
            {
                if (!char.IsLetterOrDigit(symbol) && symbol != '-' && symbol != '_')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool HasValidLength(string username, int lowerLimit, int upperLimit)
        {
            if (username.Length < lowerLimit || username.Length > upperLimit)
            {
                return false;
            }

            return true;
        }
    }
}
