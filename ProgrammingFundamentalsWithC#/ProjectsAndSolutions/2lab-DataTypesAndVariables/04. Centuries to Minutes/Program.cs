using System;

namespace _04._Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            uint centuries = uint.Parse(Console.ReadLine());

            uint years = centuries * 100;
            uint days =  (uint)(years * 365.2422);
            uint hours = days * 24;
            uint minutes = hours * 60;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
