using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string result = GetMiddle(text);

            Console.WriteLine(result);
        }

        private static string GetMiddle(string text)
        {
            if ((text.Length) % 2 == 0 )
            {
                return $"{text[text.Length / 2 - 1]}{text[text.Length / 2]}";
            }
            else
            {
                return $"{text[text.Length / 2]}";
            }
        }
    }
}
