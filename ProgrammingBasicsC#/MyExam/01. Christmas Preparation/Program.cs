using System;

namespace _01._Christmas_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPapers = int.Parse(Console.ReadLine());
            int numberOfFabrics = int.Parse(Console.ReadLine());
            double litresOfClue = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double bill = ((numberOfPapers * 5.80) + (numberOfFabrics * 7.20) + (litresOfClue * 1.20)) - (discount / 100.0) * ((numberOfPapers * 5.80) + (numberOfFabrics * 7.20) + (litresOfClue * 1.20));

            Console.WriteLine($"{bill:f3}");
        }
    }
}
