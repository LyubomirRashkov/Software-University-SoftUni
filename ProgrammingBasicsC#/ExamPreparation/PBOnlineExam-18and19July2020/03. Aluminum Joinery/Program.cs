using System;

namespace _03._Aluminum_Joinery
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfJoinery = int.Parse(Console.ReadLine());
            string kindOfJoinery = Console.ReadLine();
            string delivery = Console.ReadLine();

            double pricePerUnit = 0;

            switch (kindOfJoinery)
            {
                case "90X130":
                    pricePerUnit = 110;
                    if (numberOfJoinery > 60)
                    {
                        pricePerUnit *= 0.92;
                    }
                    else if (numberOfJoinery > 30)
                    {
                        pricePerUnit *= 0.95;
                    }
                    break;

                case "100X150":
                    pricePerUnit = 140;
                    if (numberOfJoinery > 80)
                    {
                        pricePerUnit *= 0.9;
                    }
                    else if (numberOfJoinery > 40)
                    {
                        pricePerUnit *= 0.94;
                    }
                    break;

                case "130X180":
                    pricePerUnit = 190;
                    if (numberOfJoinery > 50)
                    {
                        pricePerUnit *= 0.88;
                    }
                    else if (numberOfJoinery > 20)
                    {
                        pricePerUnit *= 0.93;
                    }
                    break;

                case "200X300":
                    pricePerUnit = 250;
                    if (numberOfJoinery > 50)
                    {
                        pricePerUnit *= 0.86;
                    }
                    else if (numberOfJoinery > 25)
                    {
                        pricePerUnit *= 0.91;
                    }
                    break;
            }

            double priceForAllJoinery = pricePerUnit * numberOfJoinery;

            switch (delivery)
            {
                case "With delivery":
                    priceForAllJoinery += 60;
                    break;
            }

            if (numberOfJoinery > 99)
            {
                priceForAllJoinery *= 0.96;
            }

            if (numberOfJoinery < 10 )
            {
                Console.WriteLine("Invalid order");
            }
            else
            {
                Console.WriteLine($"{priceForAllJoinery:f2} BGN");
            }
        }
    }
}
