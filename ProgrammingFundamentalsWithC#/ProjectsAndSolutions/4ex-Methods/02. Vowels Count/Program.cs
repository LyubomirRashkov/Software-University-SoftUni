using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int vowelsCount = GetVowelsCount(text);

            Console.WriteLine(vowelsCount);
        }

        private static int GetVowelsCount(string text)
        {
            text = text.ToLower();

            int vowelsCount = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'a' || text[i] == 'o' || text[i] == 'u' || text[i] == 'i' || text[i] == 'e' || text[i] == 'y')
                {
                    vowelsCount++;
                }
            }

            return vowelsCount;
        }
    }
}
