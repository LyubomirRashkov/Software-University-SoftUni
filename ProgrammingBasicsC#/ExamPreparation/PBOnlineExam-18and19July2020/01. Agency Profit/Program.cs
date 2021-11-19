using System;

namespace _01._Agency_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfCompany = Console.ReadLine();
            int numberOfTicketsForAdults = int.Parse(Console.ReadLine());
            int numberOfTicketsForChildren = int.Parse(Console.ReadLine());
            double priceForOneTicketForAdult = double.Parse(Console.ReadLine());
            double priceForService = double.Parse(Console.ReadLine());

            double priceForOneTicketForChildren = 0.3 * priceForOneTicketForAdult;

            double priceForAllTickets = (numberOfTicketsForAdults * priceForOneTicketForAdult) + (numberOfTicketsForChildren * priceForOneTicketForChildren) + (numberOfTicketsForAdults + numberOfTicketsForChildren) * priceForService;

            double profit = 0.2 * priceForAllTickets;

            Console.WriteLine($"The profit of your agency from {nameOfCompany} tickets is {(profit):f2} lv.");
        }
    }
}
