using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int term = int.Parse(Console.ReadLine());
            double annualInterestRate = double.Parse(Console.ReadLine());

            double monthlyInterestRate = (annualInterestRate / 12) / 100;
            double sum = deposit + term * deposit * monthlyInterestRate;

            Console.WriteLine(Math.Round(sum,2));
        }
    }
}
