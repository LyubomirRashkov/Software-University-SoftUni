using System;

namespace _03._Film_Premiere
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            string package = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());

            double pricePerTicket = 0;

            switch (projection)
            {
                case "John Wick":
                    if (package == "Drink")
                    {
                        pricePerTicket = 12;
                    }
                    else if (package == "Popcorn")
                    {
                        pricePerTicket = 15;
                    }
                    else if (package == "Menu")
                    {
                        pricePerTicket = 19;
                    }
                    break;
                case "Star Wars":
                    if (package == "Drink")
                    {
                        pricePerTicket = 18;
                    }
                    else if (package == "Popcorn")
                    {
                        pricePerTicket = 25;
                    }
                    else if (package == "Menu")
                    {
                        pricePerTicket = 30;
                    }
                    break;
                case "Jumanji":
                    if (package == "Drink")
                    {
                        pricePerTicket = 9;
                    }
                    else if (package == "Popcorn")
                    {
                        pricePerTicket = 11;
                    }
                    else if (package == "Menu")
                    {
                        pricePerTicket = 14;
                    }
                    break;
            }

            if (projection == "Star Wars" && tickets>= 4)
            {
                pricePerTicket *= 0.7;
            }

            if (projection == "Jumanji" && tickets == 2)
            {
                pricePerTicket *= 0.85;
            }

            Console.WriteLine($"Your bill is {(pricePerTicket * tickets):f2} leva.");
        }
    }
}
