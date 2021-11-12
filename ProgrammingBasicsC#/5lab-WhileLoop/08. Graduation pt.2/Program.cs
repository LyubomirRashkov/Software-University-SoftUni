using System;

namespace _08._Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int gradesCounter = 0;
            int poorGradesCounter = 0;
            double sumOfGrades = 0;
            double averageGrade = 0;

            while (gradesCounter < 12)
            {
                double grade = double.Parse(Console.ReadLine());

                gradesCounter += 1;

                if (grade < 4)
                {
                    poorGradesCounter += 1;
                }

                if (poorGradesCounter == 2)
                {
                    break;
                }

                sumOfGrades += grade;
            }

            averageGrade = sumOfGrades / gradesCounter;

            if (poorGradesCounter == 2)
            {
                 Console.WriteLine($"{name} has been excluded at {gradesCounter - 1} grade");
            }

            else
            {
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
            }
        }
    }
}
