using System;

namespace _07._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            int freeSeats = 0;
            string typeOfTicket = "";

            int counterOfStandardTicketsForTheCurrentMovie = 0;
            int counterOfStudentTicketsForTheCurrentMovie = 0;
            int counterOfKidTicketsForTheCurrentMovie = 0;

            int counterOfAllStandardTickets = 0;
            int counterOfAllStudentTickets = 0;
            int counterOfAllKidTickets = 0;

            int sumOfTicketsForTheCurrentMovie = 0;
            int sumOfAllTickets = 0;

            while (movieName != "Finish")
            {
                freeSeats = int.Parse(Console.ReadLine());

                counterOfStandardTicketsForTheCurrentMovie = 0;
                counterOfStudentTicketsForTheCurrentMovie = 0;
                counterOfKidTicketsForTheCurrentMovie = 0;

                sumOfTicketsForTheCurrentMovie = 0;

                for (int i = 1; i <= freeSeats; i++)
                {
                    typeOfTicket = Console.ReadLine();

                    if (typeOfTicket == "standard")
                    {
                        counterOfStandardTicketsForTheCurrentMovie++;
                        counterOfAllStandardTickets++;
                    }
                    else if (typeOfTicket == "student")
                    {
                        counterOfStudentTicketsForTheCurrentMovie++;
                        counterOfAllStudentTickets++;
                    }
                    else if (typeOfTicket == "kid")
                    {
                        counterOfKidTicketsForTheCurrentMovie++;
                        counterOfAllKidTickets++;
                    }
                    else if (typeOfTicket == "End")
                    {
                        break;
                    }
                }

                sumOfTicketsForTheCurrentMovie = counterOfStandardTicketsForTheCurrentMovie + counterOfStudentTicketsForTheCurrentMovie + counterOfKidTicketsForTheCurrentMovie;
                Console.WriteLine($"{movieName} - {((1.0 * sumOfTicketsForTheCurrentMovie / freeSeats) * 100):f2}% full.");

                movieName = Console.ReadLine();
            }

            sumOfAllTickets = counterOfAllStudentTickets + counterOfAllStandardTickets + counterOfAllKidTickets;

            Console.WriteLine($"Total tickets: {sumOfAllTickets}");
            Console.WriteLine($"{((1.0 * counterOfAllStudentTickets / sumOfAllTickets) * 100):f2}% student tickets.");
            Console.WriteLine($"{((1.0 * counterOfAllStandardTickets / sumOfAllTickets) * 100):f2}% standard tickets.");
            Console.WriteLine($"{((1.0 * counterOfAllKidTickets / sumOfAllTickets) * 100):f2}% kids tickets.");
        }
    }
}
