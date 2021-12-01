using System;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int countOfRotations = int.Parse(Console.ReadLine());

            int neededRotations = countOfRotations % array.Length;

            for (int i = 0; i < neededRotations; i++)
            {
                string firstElement = array[0];

                for (int j = 0; j < array.Length-1; j++)
                {
                    array[j] = array[j + 1];
                }

                array[array.Length - 1] = firstElement;
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
