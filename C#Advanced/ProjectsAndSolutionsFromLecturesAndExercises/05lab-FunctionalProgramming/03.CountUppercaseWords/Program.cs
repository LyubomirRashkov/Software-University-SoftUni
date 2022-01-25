using System;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputWords = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> isValid = str => char.IsUpper(str[0]);

            Action<string> print = str => Console.WriteLine(str);

            foreach (string word in inputWords)
            {
                if (isValid(word))
                {
                    print(word);
                }
            }
        }
    }
}
