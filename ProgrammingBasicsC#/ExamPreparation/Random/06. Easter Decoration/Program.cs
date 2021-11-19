using System;

namespace _06._Easter_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfClients = int.Parse(Console.ReadLine());

            double allBills = 0;

            for (int i = 1; i <= numberOfClients; i++)
            {
                string input = Console.ReadLine();
                double clientBill = 0;
                double currentBill = 0;
                int counterOfProducts = 0;

                while (input != "Finish")
                {
                    counterOfProducts++;
                    switch (input)
                    {
                        case "basket":
                            currentBill = 1.5;
                            break;
                        case "wreath":
                            currentBill = 3.8;
                            break;
                        case "chocolate bunny":
                            currentBill = 7;
                            break;
                    }
                    clientBill += currentBill;

                    input = Console.ReadLine();
                }
                if (counterOfProducts % 2 == 0)
                {
                    clientBill *= 0.8;
                }
                Console.WriteLine($"You purchased {counterOfProducts} items for {clientBill:f2} leva.");
                allBills += clientBill;
            }

            Console.WriteLine($"Average bill per client is: {(allBills / numberOfClients):f2} leva.");
            


        }
    }
}
