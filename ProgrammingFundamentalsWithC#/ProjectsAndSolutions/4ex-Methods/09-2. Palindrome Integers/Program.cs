﻿using System;
using System.Linq;

namespace _09_2._Palindrome_Integers
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
            for (int i = 0; i <= input.Length - 1; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
