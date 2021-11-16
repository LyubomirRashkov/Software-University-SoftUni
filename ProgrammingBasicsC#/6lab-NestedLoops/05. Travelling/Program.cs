using System;

namespace _05._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            double requiredMoney = 0;
            double savedMoney = 0;

            double allSavedMoney = 0;

            while (destination != "End")
            {
                requiredMoney = double.Parse(Console.ReadLine());
                allSavedMoney = 0;

                while (allSavedMoney < requiredMoney)
                {
                    savedMoney = double.Parse(Console.ReadLine());
                    allSavedMoney += savedMoney;
                }

                Console.WriteLine($"Going to {destination}!");

                destination = Console.ReadLine();
            }
        }
    }
}
