using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex emailRegex = new Regex(@"(?<=\s)[A-Za-z\d]+([-_\.][A-za-z\d]+)*@[A-Za-z]+([-\.][A-Za-z]+)*(\.[A-Za-z]+){1}");

            MatchCollection matches = emailRegex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
