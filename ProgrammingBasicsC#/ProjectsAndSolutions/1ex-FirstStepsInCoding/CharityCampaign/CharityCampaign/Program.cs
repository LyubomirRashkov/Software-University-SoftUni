using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int bakers = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            int cakesPricePerBakerPerDay = cakes * 45;
            double wafflesPricePerBakerPerDay = waffles * 5.80;
            double pancakesPricePerBakerPerDay = pancakes * 3.20;

            double productionPricePerBakerPerDay = cakesPricePerBakerPerDay + wafflesPricePerBakerPerDay + pancakesPricePerBakerPerDay;

            double productionPrice = productionPricePerBakerPerDay * days * bakers;

            double profit = productionPrice * (7.0 / 8);

            Console.WriteLine(Math.Round(profit,2));
        }
    }
}
