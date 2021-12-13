using System;

namespace _01.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int randomPosition = rnd.Next(words.Length);
                string temp = words[i];
                words[i] = words[randomPosition];
                words[randomPosition] = temp;
            }

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
