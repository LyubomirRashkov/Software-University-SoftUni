using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    public class Demon
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public double Damage { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] inputDemons = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            List<Demon> demons = new List<Demon>(inputDemons.Length);

            Regex healthRegex = new Regex(@"[^\d+\-*/.]");

            Regex initialDamageRegex = new Regex(@"[+|-]{0,1}\d+\.?\d*");

            Regex damageModifierRegex = new Regex(@"[/*]");

            for (int i = 0; i < inputDemons.Length; i++)
            {
                string name = inputDemons[i];

                MatchCollection matches = healthRegex.Matches(name);

                int health = CalculateHealth(matches);

                MatchCollection matches2 = initialDamageRegex.Matches(name);

                double initialDamage = CalculateInitialDamage(matches2);

                MatchCollection matches3 = damageModifierRegex.Matches(name);

                double modifiedDamage = CalculateModifiedDamage(initialDamage, matches3);

                Demon demon = new Demon
                {
                    Name = name,
                    Health = health,
                    Damage = modifiedDamage
                };

                demons.Add(demon);
            }

            List<Demon> sortedDemons = demons
                .OrderBy(d => d.Name)
                .ToList();

            foreach (Demon demon in sortedDemons)
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }
        }

        private static double CalculateModifiedDamage(double initialDamage, MatchCollection matchCollection)
        {
            foreach (Match match in matchCollection)
            {
                if (match.Value == "*")
                {
                    initialDamage *= 2;
                }
                else
                {
                    initialDamage /= 2;
                }
            }

            return initialDamage;
        }

        private static double CalculateInitialDamage(MatchCollection matchCollection)
        {
            double initialDamage = 0;

            foreach (Match match in matchCollection)
            {
                initialDamage += double.Parse(match.Value);
            }

            return initialDamage;
        }

        private static int CalculateHealth(MatchCollection matchCollection)
        {
            int health = 0;

            foreach (Match match in matchCollection)
            {
                char currentChar = char.Parse(match.Value);

                health += currentChar;
            }

            return health;
        }
    }
}
