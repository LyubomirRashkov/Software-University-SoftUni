using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int trips = int.Parse(Console.ReadLine());

            double saturdays = (48 - trips) * (3.0 / 4);
            double holidaysWithPlay = holidays * (2.0 / 3);

            double numberOfPlays = saturdays + trips + holidaysWithPlay;

            if (year == "leap")
            {
                numberOfPlays = numberOfPlays * 1.15;
            }

            Console.WriteLine(Math.Floor(numberOfPlays));
        }
    }
}
