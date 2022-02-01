using System;

namespace _05.DateModifier
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int days = DateModifier.CalculateDateDifferenceInDays(firstDate, secondDate);

            Console.WriteLine(days);
        }
    }
}
