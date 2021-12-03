using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            PrintingChars(firstChar, secondChar);
        }

        private static void PrintingChars(char start, char end)
        {
            if ((int)start > (int)end)
            {
                char temp = start;
                start = end;
                end = temp;
            }

            for (char i = (char)(start + 1); i < end; i++)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
        }
    }
}
