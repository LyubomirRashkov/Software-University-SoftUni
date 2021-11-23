using System;

namespace _04._Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int minutesAfter30 = minutes + 30;

            if (minutesAfter30 > 59)
            {
                hours++;
                minutesAfter30 -= 60;

                if (hours > 23)
                {
                    hours = 0;
                }
            }

            Console.WriteLine($"{hours}:{minutesAfter30:D2}");
        }
    }
}
