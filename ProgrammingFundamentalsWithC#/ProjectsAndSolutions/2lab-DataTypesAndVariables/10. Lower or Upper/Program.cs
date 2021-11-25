using System;

namespace _10._Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char character = char.Parse(Console.ReadLine());

            if ((int) character >= 65 && (int) character <= 90)
            {
                Console.WriteLine("upper-case");
            }
            else if ((int) character >= 97 && (int) character <= 122)
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
