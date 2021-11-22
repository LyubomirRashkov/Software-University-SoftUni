using System;

namespace _03._Courier_Express
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            int distance = int.Parse(Console.ReadLine());

            double pricePerKilometer = 0;
            double additionalPrice = 0;
            double fullPrice = 0;

            if (weight < 1)
            {
                pricePerKilometer = 0.03;
            }
            else if (weight >= 1 && weight < 10)
            {
                pricePerKilometer = 0.05;
            }
            else if (weight >= 10 && weight < 40)
            {
                pricePerKilometer = 0.1;
            }
            else if (weight >= 40 && weight < 90)
            {
                pricePerKilometer = 0.15;
            }
            else if (weight >= 90 && weight <= 150)
            {
                pricePerKilometer = 0.2;
            }

            if (type == "express")
            {
                if (weight < 1)
                {
                    additionalPrice = (0.8 * 0.03) * weight;
                }
                else if (weight >= 1 && weight < 10)
                {
                    additionalPrice = (0.4 * 0.05) * weight;
                }
                else if (weight >= 10 && weight < 40)
                {
                    additionalPrice = (0.05 * 0.1) * weight;
                }
                else if (weight >= 40 && weight < 90)
                {
                    additionalPrice = (0.02 * 0.15) * weight;
                }
                else if (weight >= 90 && weight <= 150)
                {
                    additionalPrice = (0.01 * 0.2) * weight;
                }
            }

            fullPrice = (pricePerKilometer * distance) + (additionalPrice * distance);

            Console.WriteLine($"The delivery of your shipment with weight of {weight:f3} kg. would cost {fullPrice:f2} lv.");
        }
    }
}
