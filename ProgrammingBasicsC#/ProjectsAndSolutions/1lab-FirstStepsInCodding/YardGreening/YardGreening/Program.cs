using System;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double squaremeters = double.Parse(Console.ReadLine());

            double fullPrice = squaremeters * 7.61;
            double discount = 0.18 * fullPrice;
            double finalPrice = fullPrice - discount;

            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
