using System;

namespace _04_2.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            foreach (string word in bannedWords)
            {
                string replacement = new string('*', word.Length);

                text = text.Replace(word, replacement);
            }

            Console.WriteLine(text);
        }
    }
}
