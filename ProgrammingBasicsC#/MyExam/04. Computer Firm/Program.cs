using System;

namespace _04._Computer_Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfComputers = int.Parse(Console.ReadLine());
            int input = 0;

            int rating = 0;
            int possibleSells = 0;
            double sells = 0;
            double allSells = 0;
            int sumOfRatings = 0;

            for (int i = 1; i <= numberOfComputers; i++)
            {
                input = int.Parse(Console.ReadLine());

                rating = input % 10;
                possibleSells = input / 10;

                if (rating == 2)
                {
                    sells = 0 * possibleSells;
                }
                else if (rating == 3)
                {
                    sells = 0.5 * possibleSells;
                }
                else if (rating == 4)
                {
                    sells = 0.7 * possibleSells;
                }
                else if (rating == 5)
                {
                    sells = 0.85 * possibleSells;
                }
                else if (rating == 6)
                {
                    sells = 1 * possibleSells;
                }

                allSells += sells;
                sumOfRatings += rating;
            }

            Console.WriteLine($"{allSells:f2}");
            Console.WriteLine($"{((sumOfRatings * 1.0) / numberOfComputers):f2}");
        }
    }
}
