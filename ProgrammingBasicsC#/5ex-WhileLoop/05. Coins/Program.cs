using System;

namespace _05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());

            int coins = 0;

            double changeInCoins = change * 100;

            int changeInCoinsToInt = (int)changeInCoins;

            while (changeInCoinsToInt > 0)
            {
                if (changeInCoinsToInt - 200 >= 0)
                {
                    coins++;
                    changeInCoinsToInt -= 200;
                }
                else if (changeInCoinsToInt - 100 >= 0)
                {
                    coins++;
                    changeInCoinsToInt -= 100;
                }
                else if (changeInCoinsToInt - 50 >= 0)
                {
                    coins++;
                    changeInCoinsToInt -= 50;
                }
                else if (changeInCoinsToInt - 20 >= 0)
                {
                    coins++;
                    changeInCoinsToInt -= 20;
                }
                else if (changeInCoinsToInt - 10 >= 0)
                {
                    coins++;
                    changeInCoinsToInt -= 10;
                }
                else if (changeInCoinsToInt - 5 >= 0)
                {
                    coins++;
                    changeInCoinsToInt -= 5;
                }
                else if (changeInCoinsToInt - 2 >= 0)
                {
                    coins++;
                    changeInCoinsToInt -= 2;
                }
                else if (changeInCoinsToInt - 1 >= 0)
                {
                    coins++;
                    changeInCoinsToInt -= 1;
                }
            }

            Console.WriteLine(coins);
        }
    }
}
