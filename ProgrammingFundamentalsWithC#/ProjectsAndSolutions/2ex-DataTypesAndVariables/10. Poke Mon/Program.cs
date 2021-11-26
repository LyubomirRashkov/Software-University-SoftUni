using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int counterOfPokes = 0;
            double halfPower = 0.5 * power;

            while (power >= distance)
            {
                power -= distance;
                counterOfPokes++;

                if (power == halfPower && exhaustionFactor != 0)
                {
                    power /= exhaustionFactor;
                }
            }

            Console.WriteLine(power);
            Console.WriteLine(counterOfPokes);
        }
    }
}
