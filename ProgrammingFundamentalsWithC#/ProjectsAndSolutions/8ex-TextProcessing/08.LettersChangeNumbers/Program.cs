using System;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parts = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            for (int i = 0; i < parts.Length; i++)
            {
                string currentPart = parts[i];

                char firstLetter = char.Parse(currentPart.Substring(0, 1));
                char lastLetter = char.Parse(currentPart.Substring(currentPart.Length - 1));
                double number = double.Parse(currentPart.Substring(1, currentPart.Length - 2));

                if (char.IsUpper(firstLetter))
                {
                    number /= (firstLetter - 64);
                }
                else
                {
                    number *= (firstLetter - 96);
                }

                if (char.IsUpper(lastLetter))
                {
                    number -= (lastLetter - 64);
                }
                else
                {
                    number += (lastLetter - 96);
                }

                sum += number;
            }

            Console.WriteLine($"{sum:F2}");
        }
    }
}
