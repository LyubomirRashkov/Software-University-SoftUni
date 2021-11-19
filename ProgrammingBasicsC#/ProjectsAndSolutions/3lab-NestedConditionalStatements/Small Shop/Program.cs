using System;

namespace Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double priceForOneProduct = 0;

            if (town == "Sofia")
            {
                if (product == "coffee")
                {
                    priceForOneProduct = 0.50;
                }
                else if (product == "water")
                {
                    priceForOneProduct = 0.80;
                }
                else if (product == "beer")
                {
                    priceForOneProduct = 1.20;
                }
                else if (product == "sweets")
                {
                    priceForOneProduct = 1.45;
                }
                else if (product == "peanuts")
                {
                    priceForOneProduct = 1.60;
                }
            }
            else if (town == "Plovdiv")
            {
                if (product == "coffee")
                {
                    priceForOneProduct = 0.40;
                }
                else if (product == "water")
                {
                    priceForOneProduct = 0.70;
                }
                else if (product == "beer")
                {
                    priceForOneProduct = 1.15;
                }
                else if (product == "sweets")
                {
                    priceForOneProduct = 1.30;
                }
                else if (product == "peanuts")
                {
                    priceForOneProduct = 1.50;
                }
            }
            else if (town == "Varna")
            {
                if (product == "coffee")
                {
                    priceForOneProduct = 0.45;
                }
                else if (product == "water")
                {
                    priceForOneProduct = 0.70;
                }
                else if (product == "beer")
                {
                    priceForOneProduct = 1.10;
                }
                else if (product == "sweets")
                {
                    priceForOneProduct = 1.35;
                }
                else if (product == "peanuts")
                {
                    priceForOneProduct = 1.55;
                }
            }

            double fullPrice = quantity * priceForOneProduct;

            Console.WriteLine(fullPrice);
        }
    }
}
