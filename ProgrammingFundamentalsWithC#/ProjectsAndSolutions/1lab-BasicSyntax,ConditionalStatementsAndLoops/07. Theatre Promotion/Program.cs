using System;

namespace _07._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            int pricePerTicket = 0;

            if (age < 0 || age > 122)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                if (age >= 0 && age <= 18)
                {
                    if (typeOfDay == "Weekday")
                    {
                        pricePerTicket = 12;
                    }
                    else if (typeOfDay == "Weekend")
                    {
                        pricePerTicket = 15;
                    }
                    else
                    {
                        pricePerTicket = 5;
                    }
                }
                else if (age > 18 && age <= 64)
                {
                    if (typeOfDay == "Weekday")
                    {
                        pricePerTicket = 18;
                    }
                    else if (typeOfDay == "Weekend")
                    {
                        pricePerTicket = 20;
                    }
                    else
                    {
                        pricePerTicket = 12;
                    }
                }
                else if (age > 64)
                {
                    if (typeOfDay == "Weekday")
                    {
                        pricePerTicket = 12;
                    }
                    else if (typeOfDay == "Weekend")
                    {
                        pricePerTicket = 15;
                    }
                    else
                    {
                        pricePerTicket = 10;
                    }
                }

                Console.WriteLine($"{pricePerTicket}$");
            }
        }
    }
}
