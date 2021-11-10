using System;

namespace _11._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMashinePrice = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());

            int moneyFromPresents = 0;
            int allMoneyFromPresents = 0;
            double moneyFromToys = 0;
            double allMoney = 0;
            double diff = 0; 

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    moneyFromPresents = moneyFromPresents + 10;
                    allMoneyFromPresents = allMoneyFromPresents + moneyFromPresents;
                    allMoneyFromPresents -= 1;
                }
                else
                {
                    moneyFromToys += toyPrice;
                }
            }

            allMoney = allMoneyFromPresents + moneyFromToys;

            diff = Math.Abs(allMoney - washingMashinePrice);

            if (allMoney >= washingMashinePrice)
            {
                Console.WriteLine($"Yes! {diff:f2}");
            }
            else
            {
                Console.WriteLine($"No! {diff:f2}");
            }
        }
    }
}
