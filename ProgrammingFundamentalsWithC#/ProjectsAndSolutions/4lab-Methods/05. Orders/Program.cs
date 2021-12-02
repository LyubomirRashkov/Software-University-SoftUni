using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double result = CalculateThePrice(product, quantity);

            Console.WriteLine($"{result:F2}");
        }

        private static double CalculateThePrice(string product, double quantity)
        {
            double singlePrice;

            if (product == "coffee")
            {
                singlePrice = 1.50;
            }
            else if (product == "water")
            {
                singlePrice = 1.00;
            }
            else if (product == "coke")
            {
                singlePrice = 1.40;
            }
            else
            {
                singlePrice = 2.00;
            }

            return (quantity * singlePrice);
        }
    }
}
