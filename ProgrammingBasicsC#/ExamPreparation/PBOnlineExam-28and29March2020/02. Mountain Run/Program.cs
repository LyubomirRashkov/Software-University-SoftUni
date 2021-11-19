using System;

namespace _02._Mountain_Run
{
    class Program
    {
        static void Main(string[] args)
        {
            double oldRecord = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());

            double clearTime = meters * timePerMeter;

            double numberOfDelays = Math.Floor(meters / 50);
            double fullTime = clearTime + numberOfDelays * 30;

            if (fullTime < oldRecord)
            {
                Console.WriteLine($"Yes! The new record is {fullTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {(fullTime - oldRecord):f2} seconds slower.");
            }
        }
    }
}
