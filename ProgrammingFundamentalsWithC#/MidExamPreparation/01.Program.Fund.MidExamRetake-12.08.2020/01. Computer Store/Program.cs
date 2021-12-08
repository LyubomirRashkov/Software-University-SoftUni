using System;

namespace _01._Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalPrice = 0;
            decimal priceWithoutTaxes = 0;
            decimal taxes = 0;
            decimal currentTax = 0;

            string customer = string.Empty;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "special" || line == "regular")
                {
                    customer = line;
                    break;
                }

                decimal currentPrice = decimal.Parse(line);

                if (currentPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }

                priceWithoutTaxes += currentPrice;
                currentTax = 0.2m * currentPrice;
                taxes += currentTax;
            }

            totalPrice = priceWithoutTaxes + taxes;

            if (customer == "special")
            {
                totalPrice *= 0.9m;
            }

            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {priceWithoutTaxes:F2}$");
                Console.WriteLine($"Taxes: {taxes:F2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPrice:F2}$");
            }
        }
    }
}
