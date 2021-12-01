using System;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfWagons = int.Parse(Console.ReadLine());

            int[] peopleInTheTrain = new int[countOfWagons];
            int sum = 0;

            for (int i = 0; i < peopleInTheTrain.Length; i++)
            {
                peopleInTheTrain[i] = int.Parse(Console.ReadLine());
                sum += peopleInTheTrain[i];
            }

            Console.WriteLine(string.Join(" ", peopleInTheTrain));
            Console.WriteLine(sum);
        }
    }
}
