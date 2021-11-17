using System;

namespace _04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeopleInTheJury = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();

            double grade = 0;
            int counter = 0;
            double sumOfAllGrades = 0;

            while (presentationName != "Finish")
            {
                double sumOfGradesForTheCurretPresentation = 0;

                for (int i = 1; i <= numberOfPeopleInTheJury; i++)
                {
                    grade = double.Parse(Console.ReadLine());
                    sumOfGradesForTheCurretPresentation += grade;
                    sumOfAllGrades += grade;
                }

                Console.WriteLine($"{presentationName} - {(sumOfGradesForTheCurretPresentation / numberOfPeopleInTheJury):f2}.");

                counter++;
                presentationName = Console.ReadLine();
            }

            Console.WriteLine($"Student's final assessment is {(sumOfAllGrades / (counter * numberOfPeopleInTheJury)):f2}.");
        }
    }
}
