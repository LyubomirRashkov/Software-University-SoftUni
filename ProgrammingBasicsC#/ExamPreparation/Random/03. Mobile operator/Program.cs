using System;

namespace _03._Mobile_operator
{
    class Program
    {
        static void Main(string[] args)
        {
            string period = Console.ReadLine();
            string type = Console.ReadLine();
            string internet = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());

            double pricePerMonth = 0;

            switch (type)
            {
                case "Small":
                    if (period == "one")
                    {
                        pricePerMonth = 9.98;
                    }
                    else
                    {
                        pricePerMonth = 8.58;
                    }
                    break;
                case "Middle":
                    if (period == "one")
                    {
                        pricePerMonth = 18.99;
                    }
                    else
                    {
                        pricePerMonth = 17.09;
                    }
                    break;
                case "Large":
                    if (period == "one")
                    {
                        pricePerMonth = 25.98;
                    }
                    else
                    {
                        pricePerMonth = 23.59;
                    }
                    break;
                case "ExtraLarge":
                    if (period == "one")
                    {
                        pricePerMonth = 35.99;
                    }
                    else
                    {
                        pricePerMonth = 31.79;
                    }
                    break;
            }

            if (internet == "yes")
            {
                if (pricePerMonth <= 10)
                {
                    pricePerMonth += 5.50;
                }
                else if (pricePerMonth <= 30)
                {
                    pricePerMonth += 4.35;
                }
                else
                {
                    pricePerMonth += 3.85;
                }
            }

            if (period == "two")
            {
                pricePerMonth *= 0.9625;
            }

            Console.WriteLine($"{(pricePerMonth * months):f2} lv.");
        }
    }
}
