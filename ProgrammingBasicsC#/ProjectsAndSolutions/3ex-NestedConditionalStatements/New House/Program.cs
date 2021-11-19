using System;

namespace New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Да се отпечата на конзолата на един ред:
            //•	Ако бюджета им е достатъчен - "Hey, you have a great garden with {броя цвета} {вид цветя} and 
            //{ останалата сума} leva left."
            //•	Ако бюджета им е НЕ достатъчен -"Not enough money, you need {нужната сума} leva more."
            //Сумата да бъде форматирана до втория знак след десетичната запетая.

            string typeOfFlowers = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double requiredMoney = 0;

            if (typeOfFlowers == "Roses")
            {
                if (numberOfFlowers <= 80)
                {
                    requiredMoney = numberOfFlowers * 5;
                }
                else if (numberOfFlowers > 80)
                {
                    requiredMoney = (numberOfFlowers * 5) * 0.9;
                }
            }
            else if (typeOfFlowers == "Dahlias")
            {
                if (numberOfFlowers <= 90)
                {
                    requiredMoney = numberOfFlowers * 3.80;
                }
                else if (numberOfFlowers > 90)
                {
                    requiredMoney = (numberOfFlowers * 3.80) * 0.85;
                }
            }
            else if (typeOfFlowers == "Tulips")
            {
                if (numberOfFlowers <= 80)
                {
                    requiredMoney = numberOfFlowers * 2.80;
                }
                else if (numberOfFlowers > 80)
                {
                    requiredMoney = (numberOfFlowers * 2.80) * 0.85;
                }
            }
            else if (typeOfFlowers == "Narcissus")
            {
                if (numberOfFlowers < 120)
                {
                    requiredMoney = (numberOfFlowers * 3) * 1.15;
                }
                else if (numberOfFlowers >= 120)
                {
                    requiredMoney = numberOfFlowers * 3;
                }
            }
            else if (typeOfFlowers == "Gladiolus")
            {
                if (numberOfFlowers < 80)
                {
                    requiredMoney = (numberOfFlowers * 2.50) * 1.2;
                }
                else if (numberOfFlowers >= 80)
                {
                    requiredMoney = numberOfFlowers * 2.50;
                }
            }

            if (requiredMoney <= budget)
            {
                Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlowers} and {(budget - requiredMoney):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(requiredMoney - budget):f2} leva more.");
            }

        }
    }
}
