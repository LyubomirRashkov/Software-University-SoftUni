using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfInputLines = int.Parse(Console.ReadLine());

            Dictionary<int, int> appearancesByNumber = new Dictionary<int, int>();

            for (int i = 0; i < countOfInputLines; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());

                if (!appearancesByNumber.ContainsKey(inputNumber))
                {
                    appearancesByNumber.Add(inputNumber, 0);
                }

                appearancesByNumber[inputNumber]++;
            }

            int specialNumber = appearancesByNumber.FirstOrDefault(x => x.Value % 2 == 0).Key;

            Console.WriteLine(specialNumber);
        }
    }
}
