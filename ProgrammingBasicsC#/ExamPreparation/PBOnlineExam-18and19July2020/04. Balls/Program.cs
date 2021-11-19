using System;

namespace _04._Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBalls = int.Parse(Console.ReadLine());
            string colourOfTheBall = "";

            double points = 0;
            int counterOfRedBalls = 0;
            int counterOfOrangeBalls = 0;
            int counterOfYellowBalls = 0;
            int counterOfWhiteBalls = 0;
            int counterOfBlackBalls = 0;
            int counterOfOtherBalls = 0;
            int counterOfAllBalls = 0;

            for (int i = 1; i <= numberOfBalls; i++)
            {
                colourOfTheBall = Console.ReadLine();
                switch (colourOfTheBall)
                {
                    case "red":
                        points += 5;
                        counterOfRedBalls++;
                        counterOfAllBalls++;
                        break;
                    case "orange":
                        points += 10;
                        counterOfOrangeBalls++;
                        counterOfAllBalls++;
                        break;
                    case "yellow":
                        points += 15;
                        counterOfYellowBalls++;
                        counterOfAllBalls++;
                        break;
                    case "white":
                        points += 20;
                        counterOfWhiteBalls++;
                        counterOfAllBalls++;
                        break;
                    case "black":
                        points = Math.Floor(points / 2);
                        counterOfBlackBalls++;
                        counterOfAllBalls++;
                        break;
                    default:
                        counterOfOtherBalls++;
                        counterOfAllBalls++;
                        break;
                }

            }

                Console.WriteLine($"Total points: {points}");
                Console.WriteLine($"Points from red balls: {counterOfRedBalls}");
                Console.WriteLine($"Points from orange balls: {counterOfOrangeBalls}");
                Console.WriteLine($"Points from yellow balls: {counterOfYellowBalls}");
                Console.WriteLine($"Points from white balls: {counterOfWhiteBalls}");
                Console.WriteLine($"Other colors picked: {counterOfOtherBalls}");
                Console.WriteLine($"Divides from black balls: {counterOfBlackBalls}");
        }
    }
}
