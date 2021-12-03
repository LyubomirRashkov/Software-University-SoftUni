using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isValid = true;

            int targetNumberOfDigits = 2;

            if (HasInvalidLength(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }

            if (ContainsInvalidCharacters(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }

            if (ContainsLessDigitsThan(password, targetNumberOfDigits))
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool ContainsLessDigitsThan(string password, int targetNumberOfDigits)
        {
            int digitsCount = 0;

            foreach (char symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    digitsCount++;

                    if (digitsCount == targetNumberOfDigits)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool ContainsInvalidCharacters(string password)
        {
            foreach (char symbol in password)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HasInvalidLength(string password)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
