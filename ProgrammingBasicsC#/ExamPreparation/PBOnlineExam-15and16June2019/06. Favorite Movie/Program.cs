using System;

namespace _06._Favorite_Movie
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            int nameLength = 0;
            int number = 0;
            int counter = 0;
            int maxsum = 0;
            string bestMovie = "";

            while (movieName != "STOP")
            {
                counter++;
                int sumOfNumbers = 0;
                nameLength = movieName.Length;

                for (int i = 0; i < nameLength; i++)
                {
                    number = movieName[i];
                    sumOfNumbers += number;
                    if (number >= 97 && number <= 122)
                    {
                        sumOfNumbers -= (2 * nameLength);
                    }
                    if (number >= 65 && number <= 90)
                    {
                        sumOfNumbers -= nameLength;
                    }

                }
                if (maxsum < sumOfNumbers)
                {
                    maxsum = sumOfNumbers;
                    bestMovie = movieName;
                }
                if (counter == 7)
                {
                    Console.WriteLine("The limit is reached.");
                    break;
                }
                movieName = Console.ReadLine();
            }

            Console.WriteLine($"The best movie for you is {bestMovie} with {maxsum} ASCII sum.");
        }
    }
}
