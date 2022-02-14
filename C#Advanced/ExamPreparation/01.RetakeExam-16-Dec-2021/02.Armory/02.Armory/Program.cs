using System;

namespace _02.Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheMatrix = int.Parse(Console.ReadLine());

            char[,] armory = new char[sizeOfTheMatrix, sizeOfTheMatrix];

            int officerRow = 0;
            int officerCol = 0;

            for (int row = 0; row < armory.GetLength(0); row++)
            {
                string currentInput = Console.ReadLine();

                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    armory[row, col] = currentInput[col];

                    if (armory[row, col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                }
            }

            int coinsPaid = 0;

            const int targetCoins = 65;

            bool isOutside = false;

            while (true)
            {
                string direction = Console.ReadLine();

                int newOfficerRow = 0;
                int newOfficerCol = 0;

                if (direction == "right")
                {
                    newOfficerCol++;
                }
                else if (direction == "left")
                {
                    newOfficerCol--;
                }
                else if (direction == "up")
                {
                    newOfficerRow--;
                }
                else if (direction == "down")
                {
                    newOfficerRow++;
                }

                armory[officerRow, officerCol] = '-';

                officerRow += newOfficerRow;
                officerCol += newOfficerCol;

                if (IsOutside(armory, officerRow, officerCol))
                {
                    isOutside = true;

                    break;
                }

                if (char.IsDigit(armory[officerRow, officerCol]))
                {
                    coinsPaid += int.Parse(armory[officerRow, officerCol].ToString());
                    armory[officerRow, officerCol] = 'A';
                }

                if (coinsPaid >= targetCoins)
                {
                    break;
                }

                if (armory[officerRow, officerCol] == 'M')
                {
                    armory[officerRow, officerCol] = '-';

                    for (int row = 0; row < armory.GetLength(0); row++)
                    {
                        for (int col = 0; col < armory.GetLength(1); col++)
                        {
                            if (armory[row, col] == 'M')
                            {
                                armory[row, col] = 'A';
                                officerRow = row;
                                officerCol = col;
                            }
                        }
                    }
                }

                if (armory[officerRow, officerCol] == '-')
                {
                    armory[officerRow, officerCol] = 'A';
                }
            }

            if (isOutside)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {coinsPaid} gold coins.");

            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    Console.Write(armory[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsOutside(char[,] armory, int row, int col)
        {
            return row < 0 || row >= armory.GetLength(0) || col < 0 || col >= armory.GetLength(1);
        }
    }
}
