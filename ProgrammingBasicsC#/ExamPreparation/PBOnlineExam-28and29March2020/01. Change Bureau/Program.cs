using System;

namespace _01._Change_Bureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBitcoins = int.Parse(Console.ReadLine());
            double numberOfYuans = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());

            double levaFromBitcoins = numberOfBitcoins * 1168;

            double dollarsFromYuans = numberOfYuans * 0.15;
            double levaFromDollars = dollarsFromYuans * 1.76;

            double allLeva = levaFromBitcoins + levaFromDollars;

            double allEuros = allLeva / 1.95;

            double result = allEuros - (commission / 100) * allEuros;

            Console.WriteLine($"{result:f2}");
                 
        }
    }
}
