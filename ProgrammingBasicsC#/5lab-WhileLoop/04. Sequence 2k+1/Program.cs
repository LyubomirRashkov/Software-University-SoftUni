using System;

namespace _04._Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int start = 1;

            while (start <= n)
            {
                Console.WriteLine(start);
                start = (start * 2) + 1;
            }
        }
    }
}
