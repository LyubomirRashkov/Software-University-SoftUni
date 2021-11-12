using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double totalMoney = 0;

            while (input != "NoMoreMoney")
            {
                double contribution = double.Parse(input);

                if (contribution < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                Console.WriteLine($"Increase: {contribution:f2}");
                totalMoney += contribution;

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total: {totalMoney:f2}");
        }
    }
}
