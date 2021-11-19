using System;

namespace _05._Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double pointsFromTheAcademy = double.Parse(Console.ReadLine());
            int numberOfJudges = int.Parse(Console.ReadLine());

            double acceptedPoints = 0;
            double allPoints = pointsFromTheAcademy;

            for (int i = 1; i <= numberOfJudges; i++)
            {
                string judgeName = Console.ReadLine();
                double pointsFromTheJudge = double.Parse(Console.ReadLine());

                acceptedPoints = (judgeName.Length * pointsFromTheJudge) / 2;
                allPoints += acceptedPoints;

                if (allPoints > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {allPoints:f1}!");
                    break;
                }

            }

            if (allPoints <= 1250.5)
            {
                Console.WriteLine($"Sorry, {actorName} you need {(1250.5 - allPoints):f1} more!");
            }
        }
    }
}
