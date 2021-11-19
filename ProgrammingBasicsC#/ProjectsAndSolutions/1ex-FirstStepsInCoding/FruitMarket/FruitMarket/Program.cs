using System;

namespace FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberriesPrice = double.Parse(Console.ReadLine());
            double bananas = double.Parse(Console.ReadLine());
            double oranges = double.Parse(Console.ReadLine());
            double raspberries = double.Parse(Console.ReadLine());
            double strawberries = double.Parse(Console.ReadLine());

            double raspberriesPrice = strawberriesPrice * 0.5;
            double orangesPrice = raspberriesPrice * 0.6;
            double bananasPrice = raspberriesPrice * 0.2;

            double sum = strawberriesPrice * strawberries + bananasPrice * bananas + orangesPrice * oranges + raspberriesPrice * raspberries;

            Console.WriteLine(Math.Round(sum,2));
        }
    }
}
