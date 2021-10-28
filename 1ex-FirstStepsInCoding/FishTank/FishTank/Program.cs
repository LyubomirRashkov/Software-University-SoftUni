using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double lengthdm = length * 0.1;
            double widthdm = width * 0.1;
            double heightdm = height * 0.1;

            double volume = lengthdm * widthdm * heightdm;

            double clearVolume = volume - (percent / 100) * volume;

            Console.WriteLine(clearVolume);
        }
    }
}
