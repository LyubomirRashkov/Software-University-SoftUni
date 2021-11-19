using System;

namespace _03._Travel_Agency
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            string package = Console.ReadLine();
            string VIP = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double priceForOneDay = 0;

            if (days > 7)
            {
                days -= 1;
            }

            if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
            }
            else
            {

                switch (city)
                {
                    case "Bansko":
                    case "Borovets":
                        if (package == "withEquipment")
                        {
                            priceForOneDay = 100;
                            if (VIP == "yes")
                            {
                                priceForOneDay *= 0.9;
                            }
                            Console.WriteLine($"The price is {(priceForOneDay * days):f2}lv! Have a nice time!");
                        }
                        else if (package == "noEquipment")
                        {
                            priceForOneDay = 80;
                            if (VIP == "yes")
                            {
                                priceForOneDay *= 0.95;
                            }
                            Console.WriteLine($"The price is {(priceForOneDay * days):f2}lv! Have a nice time!");

                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        break;
                    case "Varna":
                    case "Burgas":
                        if (package == "withBreakfast")
                        {
                            priceForOneDay = 130;
                            if (VIP == "yes")
                            {
                                priceForOneDay *= 0.88;
                            }
                            Console.WriteLine($"The price is {(priceForOneDay * days):f2}lv! Have a nice time!");

                        }
                        else if (package == "noBreakfast")
                        {
                            priceForOneDay = 100;
                            if (VIP == "yes")
                            {
                                priceForOneDay *= 0.93;
                            }
                            Console.WriteLine($"The price is {(priceForOneDay * days):f2}lv! Have a nice time!");

                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }

        }
    }
}
