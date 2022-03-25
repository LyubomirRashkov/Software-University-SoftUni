using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class StartUp
    {
        public static void Main()
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            Dictionary<string, Buyer> buyersByName = new Dictionary<string, Buyer>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] inputInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = inputInfo[0];
                int age = int.Parse(inputInfo[1]);

                if (inputInfo.Length == 4)
                {
                    string id = inputInfo[2];
                    string birthdate = inputInfo[3];

                    buyersByName.Add(name, new Citizen(name, age, id, birthdate));
                }
                else
                {
                    string group = inputInfo[2];

                    buyersByName.Add(name, new Rebel(name, age, group));
                }
            }

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "End")
                {
                    break;
                }

                string targetName = inputLine;

                if (buyersByName.ContainsKey(targetName))
                {
                    buyersByName[targetName].BuyFood();
                }
            }

            Console.WriteLine(buyersByName.Values.Sum(v => v.Food));
        }
    }
}
