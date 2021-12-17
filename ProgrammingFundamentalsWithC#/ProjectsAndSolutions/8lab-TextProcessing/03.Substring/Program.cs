using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string text = Console.ReadLine();

            while (text.IndexOf(key) >= 0)
            {
                text = text.Remove(text.IndexOf(key), key.Length);
            }

            Console.WriteLine(text);
        }
    }
}
