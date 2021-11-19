using System;

namespace _02._Add_Bags
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceForLuggageHeavierThan20Kgs = double.Parse(Console.ReadLine());
            double luggageKgs = double.Parse(Console.ReadLine());
            int daysLeft = int.Parse(Console.ReadLine());
            int luggageCounter = int.Parse(Console.ReadLine());

            double priceForAdditionalLuggage = 0;

            if (luggageKgs < 10)
            {
                priceForAdditionalLuggage = 0.2 * priceForLuggageHeavierThan20Kgs;
            }
            else if (luggageKgs >= 10 && luggageKgs <= 20)
            {
                priceForAdditionalLuggage = 0.5 * priceForLuggageHeavierThan20Kgs;
            }
            else if (luggageKgs > 20)
            {
                priceForAdditionalLuggage = priceForLuggageHeavierThan20Kgs;
            }

            if (daysLeft < 7)
            {
                priceForAdditionalLuggage *= 1.4;
            }
            else if (daysLeft >= 7 && daysLeft <= 30)
            {
                priceForAdditionalLuggage *= 1.15;
            }
            else if (daysLeft > 30)
            {
                priceForAdditionalLuggage *= 1.1;
            }

            Console.WriteLine($"The total price of bags is: {(priceForAdditionalLuggage * luggageCounter):f2} lv.");
        }
    }
}
