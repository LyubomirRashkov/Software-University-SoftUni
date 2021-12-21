using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_2.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"\+359(-| )2(\1)\d{3}(\1)\d{4}\b");

            MatchCollection matches = regex.Matches(input);

            string[] phonenumbers = matches
                .Select(x => x.ToString())
                .ToArray();

            Console.WriteLine(string.Join(", ", phonenumbers));
        }
    }
}
