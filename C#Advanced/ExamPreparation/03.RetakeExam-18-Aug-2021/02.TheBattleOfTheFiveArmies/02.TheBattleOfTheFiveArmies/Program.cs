using System;

namespace _02.TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());

            int numberOfRows = int.Parse(Console.ReadLine());

            string rowInput = Console.ReadLine();

            char[,] map = new char[numberOfRows, rowInput.Length];

            int armyRow = 0;
            int armyCol = 0;

            for (int row = 0; row < map.GetLength(0); row++)
            {
                if (row > 0)
                {
                    rowInput = Console.ReadLine();
                }

                for (int col = 0; col < map.GetLength(1); col++)
                {
                    map[row, col] = rowInput[col];

                    if (map[row, col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            bool isOutOfArmor = false;

            bool isMordorReached = false;

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string direction = input[0];
                int orcRow = int.Parse(input[1]);
                int orcCol = int.Parse(input[2]);

                map[orcRow, orcCol] = 'O';

                int newArmyRow = 0;
                int newArmyCol = 0;

                if (direction == "up")
                {
                    newArmyRow--;
                }
                else if (direction == "down")
                {
                    newArmyRow++;
                }
                else if (direction == "left")
                {
                    newArmyCol--;
                }
                else if (direction == "right")
                {
                    newArmyCol++;
                }

                if (!IsGoingInside(map, armyRow + newArmyRow, armyCol + newArmyCol))
                {
                    armor--;

                    if (armor == 0)
                    {
                        map[armyRow, armyCol] = 'X';

                        isOutOfArmor = true;

                        break;
                    }
                }
                else
                {
                    map[armyRow, armyCol] = '-';
 
                    armyRow += newArmyRow;
                    armyCol += newArmyCol;

                    armor--;

                    if (armor == 0)
                    {
                        map[armyRow, armyCol] = 'X';

                        isOutOfArmor = true;

                        break;
                    }

                    if (map[armyRow, armyCol] == 'O')
                    {
                        armor -= 2;

                        if (armor <= 0)
                        {
                            map[armyRow, armyCol] = 'X';

                            isOutOfArmor = true;

                            break;
                        }
                        else
                        {
                            map[armyRow, armyCol] = 'A';
                        }
                    }
                    else if (map[armyRow, armyCol] == 'M')
                    {
                        map[armyRow, armyCol] = '-';

                        isMordorReached = true;

                        break;
                    }
                }
            }

            if (isOutOfArmor)
            {
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }

            if (isMordorReached)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    Console.Write(map[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsGoingInside(char[,] map, int row, int col)
        {
            return row >= 0 && row < map.GetLength(0) && col >= 0 && col < map.GetLength(1);
        }
    }
}
