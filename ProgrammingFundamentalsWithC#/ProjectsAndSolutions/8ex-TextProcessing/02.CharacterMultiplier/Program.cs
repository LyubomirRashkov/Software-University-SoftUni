using System;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int totalSum = SumFromMultiplication(words[0], words[1]) + SumFromAddition(words[0], words[1]);

            Console.WriteLine(totalSum);
        }

        private static int SumFromAddition(string firstString, string secondString)
        {
            int sum = 0;

            string longerString = GetLongerString(firstString, secondString);
            int minLength = Math.Min(firstString.Length, secondString.Length);

            if (longerString == string.Empty)
            {
                return 0;
            }

            for (int i = minLength; i < longerString.Length; i++)
            {
                sum += longerString[i];
            }

            return sum;
        }

        private static string GetLongerString(string firstString, string secondString)
        {
            if (firstString.Length > secondString.Length)
            {
                return firstString;
            }
            else if (secondString.Length > firstString.Length)
            {
                return secondString;
            }

            return string.Empty;
        }

        private static int SumFromMultiplication(string firstString, string secondString)
        {
            int sum = 0;
            int minLength = Math.Min(firstString.Length, secondString.Length);

            for (int i = 0; i < minLength; i++)
            {
                int currentSum = firstString[i] * secondString[i];

                sum += currentSum;
            }

            return sum;
        }
    }
}
