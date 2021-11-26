using System;

namespace _09._Spice_Must_Flow___2
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());

            int gatheredSpice = 0;
            int daysCounter = 0;

            while (yield >= 100)
            {
                gatheredSpice += yield;
                gatheredSpice -= 26;
                daysCounter++;
                yield -= 10;
            }

            if (daysCounter > 0)
            {
                gatheredSpice -= 26;
            }

            Console.WriteLine(daysCounter);
            Console.WriteLine(gatheredSpice);
        }
    }
}
