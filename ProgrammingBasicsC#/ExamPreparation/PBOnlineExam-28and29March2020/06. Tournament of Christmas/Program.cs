using System;

namespace _06._Tournament_of_Christmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = int.Parse(Console.ReadLine());
            string input = "";

            double allMoney = 0;
            int counterOfWinsDays = 0;
            int counterOfLosesDays = 0;

            for (int i = 1; i <= numberOfDays; i++)
            {
                double raisedMoneyForTheDay = 0;
                int counterOfWins = 0;
                int counterOfLoses = 0;

                input = Console.ReadLine();

                while (input != "Finish")
                {
                    string result = Console.ReadLine();

                    if (result == "win")
                    {
                        raisedMoneyForTheDay += 20;
                        counterOfWins++;
                    }
                    else
                    {
                        counterOfLoses++;
                    }

                    input = Console.ReadLine();
                }

                if (counterOfWins > counterOfLoses )
                {
                    raisedMoneyForTheDay *= 1.1;
                    counterOfWinsDays++;
                }
                else
                {
                    counterOfLosesDays++;
                }

                allMoney += raisedMoneyForTheDay;

            }

            if (counterOfWinsDays > counterOfLosesDays)
            {
                allMoney *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {allMoney:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {allMoney:f2}");
            }
        }
    }
}
