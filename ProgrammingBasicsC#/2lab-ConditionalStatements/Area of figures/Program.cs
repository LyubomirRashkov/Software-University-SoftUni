using System;

namespace Area_of_figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string kindOfFigure = Console.ReadLine();

            double area = 0.000;

            if (kindOfFigure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                area = a * a;
                Console.WriteLine("{0:f3}",area);
            }
            else if (kindOfFigure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = a * b;
                Console.WriteLine("{0:f3}",area);
            }
            else if (kindOfFigure == "circle")
            {
                double a = double.Parse(Console.ReadLine());
                area = Math.PI * (a * a);
                Console.WriteLine("{0:f3}",area);
            }
            else
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = (a * b) / 2;
                Console.WriteLine("{0:f3}",area);
            }
        }
    }
}
