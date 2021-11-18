using System;

namespace _03._Oscars_week_in_cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            string hallType = Console.ReadLine();
            int ticketsCounter = int.Parse(Console.ReadLine());

            double ticketPrice = 0;

            if (hallType == "normal")
            {
                if (movieName == "A Star Is Born")
                {
                    ticketPrice = 7.50;
                }
                else if (movieName == "Bohemian Rhapsody")
                {
                    ticketPrice = 7.35;
                }
                else if (movieName == "Green Book")
                {
                    ticketPrice = 8.15;
                }
                else if (movieName == "The Favourite")
                {
                    ticketPrice = 8.75;
                }
            }
            else if (hallType == "luxury")
            {
                if (movieName == "A Star Is Born")
                {
                    ticketPrice = 10.50;
                }
                else if (movieName == "Bohemian Rhapsody")
                {
                    ticketPrice = 9.45;
                }
                else if (movieName == "Green Book")
                {
                    ticketPrice = 10.25;
                }
                else if (movieName == "The Favourite")
                {
                    ticketPrice = 11.55;
                }
            }
            else if (hallType == "ultra luxury")
            {
                if (movieName == "A Star Is Born")
                {
                    ticketPrice = 13.50;
                }
                else if (movieName == "Bohemian Rhapsody")
                {
                    ticketPrice = 12.75;
                }
                else if (movieName == "Green Book")
                {
                    ticketPrice = 13.25;
                }
                else if (movieName == "The Favourite")
                {
                    ticketPrice = 13.95;
                }
            }

            Console.WriteLine($"{movieName} -> {(ticketPrice * ticketsCounter):f2} lv.");
        }
    }
}
