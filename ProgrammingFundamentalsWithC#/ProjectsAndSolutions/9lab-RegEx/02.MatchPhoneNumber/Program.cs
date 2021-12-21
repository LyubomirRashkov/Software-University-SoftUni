using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"\+359(-| )2(\1)\d{3}(\1)\d{4}\b");

            MatchCollection matches = regex.Matches(input);

            List<Match> phonenumbers = new List<Match>();
           
            foreach (Match match in matches)
            {
                phonenumbers.Add(match);
            }

            Console.WriteLine(string.Join(", ", phonenumbers));
        }
    }
}
