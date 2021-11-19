using System;

namespace _01._Tennis_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceForOneTennisRacket = double.Parse(Console.ReadLine());
            int numberOfTennisRackets = int.Parse(Console.ReadLine());
            int numberOfSneakersPairs = int.Parse(Console.ReadLine());

            double priceForOneSneakersPair = priceForOneTennisRacket / 6;

            double priceForAllTennisRackets = priceForOneTennisRacket * numberOfTennisRackets;
            double priceForAllSneakersPairs = priceForOneSneakersPair * numberOfSneakersPairs;

            double priceOfAdditionalEquioment = (priceForAllTennisRackets + priceForAllSneakersPairs) / 5;

            double wholePrice = priceForAllTennisRackets + priceForAllSneakersPairs + priceOfAdditionalEquioment;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(wholePrice / 8)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling((wholePrice * 7) / 8)}");
        }
    }
}
