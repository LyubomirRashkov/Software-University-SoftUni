using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int counterOfLosses = int.Parse(Console.ReadLine());
            double priceOfAHeadset = double.Parse(Console.ReadLine());
            double priceOfAMouse = double.Parse(Console.ReadLine());
            double priceOfAKeyboard = double.Parse(Console.ReadLine());
            double priceOfADisplay = double.Parse(Console.ReadLine());

            double requiredMoney = (counterOfLosses / 2) * priceOfAHeadset + (counterOfLosses / 3) * priceOfAMouse + (counterOfLosses / 6) * priceOfAKeyboard + (counterOfLosses / 12) * priceOfADisplay;

            Console.WriteLine($"Rage expenses: {requiredMoney:F2} lv.");
        }
    }
}
