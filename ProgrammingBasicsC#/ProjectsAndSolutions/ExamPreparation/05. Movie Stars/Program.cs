using System;

namespace _05._Movie_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string actorName = Console.ReadLine();
            double requiredMoney = 0;

            while (actorName != "ACTION")
            {

                if (actorName.Length > 15)
                {
                    requiredMoney = 0.2 * budget;
                }
                else
                {
                    requiredMoney = double.Parse(Console.ReadLine());
                }

                budget -= requiredMoney;

                if (budget <= 0)
                {
                    Console.WriteLine($"We need {(Math.Abs(budget)):f2} leva for our actors.");
                    break;
                }
                actorName = Console.ReadLine();
            }
            if (budget > 0)
            {
                Console.WriteLine($"We are left with {(budget):f2} leva.");
            }
        }
    }
}
