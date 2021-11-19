using System;

namespace _04._Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double target = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int cocktailPrice = 0;
            double collectedMoney = 0;

            while (input != "Party!")
            {
                int numberOfCocktails = int.Parse(Console.ReadLine());
                double orderPrice = 0;
                cocktailPrice = input.Length;
                orderPrice = cocktailPrice * numberOfCocktails;

                if (orderPrice % 2 != 0)
                {
                    orderPrice *= 0.75;
                }

                collectedMoney += orderPrice;

                 if (target <= collectedMoney)
                 {
                    Console.WriteLine($"Target acquired.");
                    break;
                 }

                input = Console.ReadLine();
            }

            if (input == "Party!")
            {
                Console.WriteLine($"We need {(target - collectedMoney):f2} leva more.");
            }

            Console.WriteLine($"Club income - {(collectedMoney):f2} leva.");
        }
    }
}
