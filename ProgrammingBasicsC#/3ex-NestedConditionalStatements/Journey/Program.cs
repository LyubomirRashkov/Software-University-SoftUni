using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {

            //  •	Първи ред – „Somewhere in [дестинация]“ измежду “Bulgaria", "Balkans” и ”Europe”
            //  •	Втори ред – “{Вид почивка} – {Похарчена сума}“
            //  o Почивката може да е между „Camp” и „Hotel”
            //  o Сумата трябва да е закръглена с точност до вторият знак след запетаята.

            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            string accommodation = "";
            double requiredMoney = 0;

            if (budget <= 100)
            {
                destination = "Bulgaria";

                if (season == "summer")
                {
                    accommodation = "Camp";
                    requiredMoney = 0.3 * budget;
                }
                else if (season == "winter")
                {
                    accommodation = "Hotel";
                    requiredMoney = 0.7 * budget;
                }
            }

            else if (budget > 100 && budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    accommodation = "Camp";
                    requiredMoney = 0.4 * budget;
                }
                else if (season == "winter")
                {
                    accommodation = "Hotel";
                    requiredMoney = 0.8 * budget;
                }
            }

            else if (budget > 1000)
            {
                destination = "Europe";
                accommodation = "Hotel";
                requiredMoney = 0.9 * budget;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{accommodation} - {requiredMoney:f2}");
        }
    }
}
