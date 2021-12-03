using System;
using System.Linq;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                Console.WriteLine(IsPalindrome(input));
            }
        }

        private static bool IsPalindrome(string input)
        {
            string reversedInput = string.Join("", input.Reverse());

            if (input == reversedInput)
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
