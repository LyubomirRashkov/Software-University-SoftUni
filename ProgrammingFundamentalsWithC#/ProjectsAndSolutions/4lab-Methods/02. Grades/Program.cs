using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            string gradeInWords = GradeInWords(grade);

            Console.WriteLine(gradeInWords);
        }

        private static string GradeInWords(double gradeInNumber)
        {
            string gradeInWords = string.Empty;

            if (gradeInNumber >= 2.00 && gradeInNumber <= 2.99)
            {
                gradeInWords = "Fail";
            }
            else if (gradeInNumber >= 3.00 && gradeInNumber <= 3.49)
            {
                gradeInWords = "Poor";
            }
            else if (gradeInNumber >= 3.50 && gradeInNumber <= 4.49)
            {
                gradeInWords = "Good";
            }
            else if (gradeInNumber >= 4.50 && gradeInNumber <= 5.49)
            {
                gradeInWords = "Very good";
            }
            else if (gradeInNumber >= 5.50 && gradeInNumber <= 6.00)
            {
                gradeInWords = "Excellent";
            }

            return gradeInWords;
        }
    }
}
