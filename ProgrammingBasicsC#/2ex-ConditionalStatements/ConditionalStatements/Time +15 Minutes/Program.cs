using System;

namespace Time__15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            if (minutes + 15 < 60)
            {
                Console.WriteLine($"{hour}:{minutes + 15}");
            }
            if (minutes + 15 >= 60)
            {
                minutes = (minutes + 15) - 60;
                hour = hour + 1;
                if (hour > 23)
                {
                    hour = 0;
                }
                Console.WriteLine($"{hour}:{minutes:d2}");
            }
        }
    }
}
