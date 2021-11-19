using System;

namespace BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double hallRent = double.Parse(Console.ReadLine());

            double cake = hallRent * 0.2;
            double drinks = cake * 0.55;
            double animator = hallRent / 3;

            double sum = hallRent + cake + drinks + animator;

            Console.WriteLine(Math.Round(sum,2));
        }
    }
}
