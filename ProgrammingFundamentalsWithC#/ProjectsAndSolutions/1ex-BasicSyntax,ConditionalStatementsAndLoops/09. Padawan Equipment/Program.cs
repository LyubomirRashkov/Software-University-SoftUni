using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double availableMoney = double.Parse(Console.ReadLine());
            int numberOfStudents = int.Parse(Console.ReadLine());
            double priceOfALightsaber = double.Parse(Console.ReadLine());
            double priceOfARobe = double.Parse(Console.ReadLine());
            double priceOfABelt = double.Parse(Console.ReadLine());

            double requiredMoney = ((Math.Ceiling(numberOfStudents * 1.1)) * priceOfALightsaber) + (numberOfStudents * priceOfARobe) + ((numberOfStudents - numberOfStudents / 6) * priceOfABelt);

            if (requiredMoney <= availableMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {requiredMoney:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {(requiredMoney - availableMoney):F2}lv more.");
            }
        }
    }
}
