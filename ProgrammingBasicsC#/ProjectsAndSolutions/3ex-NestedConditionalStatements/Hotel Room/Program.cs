using System;

namespace Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double apartementPrice = 0;
            double studioPrice = 0;

            switch (month)
            {
                case "May":
                case "October":
                    if (nights <= 7)
                    {
                        studioPrice = nights * 50;
                        apartementPrice = nights * 65;
                    }
                    else if (nights > 7 && nights <= 14)
                    {
                        studioPrice = (nights * 50) * 0.95;
                        apartementPrice = nights * 65;
                    }
                    else if (nights > 14)
                    {
                        studioPrice = (nights * 50) * 0.7;
                        apartementPrice = (nights * 65) * 0.9;
                    }
                    break;

                case "June":
                case "September":
                    if (nights <= 14)
                    {
                        studioPrice = nights * 75.2;
                        apartementPrice = nights * 68.7;
                    }
                    else if (nights > 14)
                    {
                        studioPrice = (nights * 75.2) * 0.8;
                        apartementPrice = (nights * 68.7) * 0.9;
                    }
                    break;

                case "July":
                case "August":
                    studioPrice = nights * 76;
                    if (nights <= 14)
                    {
                        apartementPrice = nights * 77;
                    }
                    else if (nights > 14)
                    {
                        apartementPrice = (nights * 77) * 0.9;
                    }
                    break;
            }

            Console.WriteLine($"Apartment: {apartementPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}
