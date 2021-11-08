using System;

namespace Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string accommodation = Console.ReadLine();
            string feedback = Console.ReadLine();

            int nights = days - 1;

            double price = 0;

            switch (accommodation)
            {
                case "room for one person":
                    price = nights * 18;
                    break;

                case "apartment":
                    if (days < 10 )
                    {
                        price = (nights * 25) * 0.7;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        price = (nights * 25) * 0.65;
                    }
                    else
                    {
                        price = (nights * 25) * 0.5;
                    }
                    break;

                case "president apartment":
                    if (days < 10)
                    {
                        price = (nights * 35) * 0.9;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        price = (nights * 35) * 0.85;
                    }
                    else
                    {
                        price = (nights * 35) * 0.8;
                    }
                    break;
            }

            if (feedback == "positive")
            {
                price = price * 1.25;
            }
            else if (feedback == "negative")
            {
                price = price * 0.9;
            }

            Console.WriteLine("{0:f2}", price);
        }
    }
}
