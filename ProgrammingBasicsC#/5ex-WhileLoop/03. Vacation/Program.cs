using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());

            int counterOfDays = 0;
            int counterOfDaysWithSpending = 0;

            while (availableMoney < tripPrice)
            {
                string action = Console.ReadLine();
                double sum = double.Parse(Console.ReadLine());
                counterOfDays++;

                if (action == "save")
                {
                    availableMoney += sum;
                    counterOfDaysWithSpending = 0;
                }
                else if (action == "spend")
                {
                    if (sum > availableMoney)
                    {
                        sum = availableMoney;
                    }
                    availableMoney -= sum;
                    counterOfDaysWithSpending++;

                    if (counterOfDaysWithSpending == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine($"{counterOfDays}");
                        break;
                    }
                }
            }

            if (availableMoney >= tripPrice)
            {
                Console.WriteLine($"You saved the money for {counterOfDays} days.");
            }
        }
    }
}
