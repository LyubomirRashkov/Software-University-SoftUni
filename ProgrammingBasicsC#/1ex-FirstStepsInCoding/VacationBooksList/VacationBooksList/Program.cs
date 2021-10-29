using System;

namespace VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            int allowableNumOfDays = int.Parse(Console.ReadLine());

            double hoursForWholeBook = pages / pagesPerHour;
            double hoursPerDay = hoursForWholeBook / allowableNumOfDays;

            Console.WriteLine(hoursPerDay);
        }
    }
}
