using System;

namespace World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());

            double timeForWholeDistance = distance * timePerMeter;
            double waterResistance = Math.Floor(distance / 15);

            double wholeTime = timeForWholeDistance + (waterResistance * 12.5);

            if (wholeTime < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {wholeTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(wholeTime - record):f2} seconds slower.");
            }
        }
    }
}
