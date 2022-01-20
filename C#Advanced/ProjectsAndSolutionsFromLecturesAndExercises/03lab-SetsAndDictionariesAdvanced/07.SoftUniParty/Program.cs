using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIP = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "PARTY")
                {
                    break;
                }

                if (char.IsDigit(line[0]))
                {
                    VIP.Add(line);
                }
                else
                {
                    regular.Add(line);
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                if (char.IsDigit(line[0]))
                {
                    VIP.Remove(line);
                }
                else
                {
                    regular.Remove(line);
                }
            }

            int countOfAllGuestsThatDidNotCome = VIP.Count + regular.Count;

            Console.WriteLine(countOfAllGuestsThatDidNotCome);

            foreach (string name in VIP)
            {
                Console.WriteLine(name);
            }

            foreach (string name in regular)
            {
                Console.WriteLine(name);
            }
        }
    }
}
