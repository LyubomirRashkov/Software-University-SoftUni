using System;

namespace _04._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double numbersSmallerThan200 = 0;
            double numbersBetween200And399 = 0;
            double numbersBetween400And599 = 0;
            double numbersBetween600And799 = 0;
            double numbersBiggerThan800 = 0;

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            for (int i = 1; i <= n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber < 200)
                {
                    numbersSmallerThan200 += 1;
                }
                else if (currentNumber >= 200 && currentNumber <= 399)
                {
                    numbersBetween200And399 += 1;
                }
                else if (currentNumber >= 400 && currentNumber <= 599)
                {
                    numbersBetween400And599 += 1;
                }
                else if (currentNumber >= 600 && currentNumber <= 799)
                {
                    numbersBetween600And799 += 1;
                }
                else if (currentNumber >= 800)
                {
                    numbersBiggerThan800 += 1;
                }
            }

            p1 = (numbersSmallerThan200 / n) * 100;
            p2 = (numbersBetween200And399 / n) * 100;
            p3 = (numbersBetween400And599 / n) * 100;
            p4 = (numbersBetween600And799 / n) * 100;
            p5 = (numbersBiggerThan800 / n) * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
