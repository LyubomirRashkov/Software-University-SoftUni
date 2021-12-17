using System;
using System.Text;

namespace _04.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                string bannedWord = bannedWords[i];
                StringBuilder newWord = new StringBuilder();

                for (int j = 0; j < bannedWord.Length; j++)
                {
                    string addition = "*";
                    newWord.Append(addition);
                }

                text = text.Replace(bannedWord, newWord.ToString());
            }

            Console.WriteLine(text);
        }
    }
}
