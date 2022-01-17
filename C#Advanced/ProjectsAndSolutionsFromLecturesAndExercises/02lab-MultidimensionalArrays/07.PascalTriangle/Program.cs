using System;

namespace _07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfJagged = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[sizeOfJagged][];

            for (int i = 0; i < pascalTriangle.Length; i++)
            {
                pascalTriangle[i] = new long[i + 1];

                pascalTriangle[i][0] = 1;
                pascalTriangle[i][pascalTriangle[i].Length - 1] = 1;

                for (int j = 1; j < pascalTriangle[i].Length - 1; j++)
                {
                    pascalTriangle[i][j] = pascalTriangle[i - 1][j] + pascalTriangle[i - 1][j - 1];
                }
            }

            for (int i = 0; i < pascalTriangle.Length; i++)
            {
                Console.WriteLine(string.Join(" ", pascalTriangle[i]));
            }
        }
    }
}
