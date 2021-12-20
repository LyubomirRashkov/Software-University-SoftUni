using System;
using System.Text;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int explosionStrength = 0;

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    explosionStrength += int.Parse(input[i + 1].ToString());
                    result.Append(input[i]);
                }
                else
                {
                    if (explosionStrength == 0)
                    {
                        result.Append(input[i]);
                    }
                    else
                    {
                        explosionStrength--;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
