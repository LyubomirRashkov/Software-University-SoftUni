using System;

namespace Scholarships
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double GPA = double.Parse(Console.ReadLine());
            double minimalWage = double.Parse(Console.ReadLine());

            double socialScholarship = 0.35 * minimalWage;
            double excellentResultsScholarship = GPA * 25;

            if (income < minimalWage && GPA >= 5.50)
            {
                if (excellentResultsScholarship >= socialScholarship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentResultsScholarship)} BGN!");
                }
                else
                {
                    Console.WriteLine($"You get a social scholarship {Math.Floor(socialScholarship)} BGN!");
                }
            }

            else if (income < minimalWage && GPA > 4.50)
            {
                Console.WriteLine($"You get a social scholarship {Math.Floor(socialScholarship)} BGN!");
            }

            else if (GPA >= 5.50)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentResultsScholarship)} BGN!");
            }

            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
