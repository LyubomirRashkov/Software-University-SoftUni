using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    public class StartUp
    {
        public static void Main()
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "End")
                {
                    break;
                }

                string[] inputInfo = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (inputInfo.Length == 3)
                {
                    string citizenName = inputInfo[0];
                    int citizenAge = int.Parse(inputInfo[1]);
                    string citizenId = inputInfo[2];

                    IIdentifiable citizen = new Citizen(citizenName, citizenAge, citizenId);

                    identifiables.Add(citizen);
                }
                else
                {
                    string robotModel = inputInfo[0];
                    string robotId = inputInfo[1];

                    IIdentifiable robot = new Robot(robotModel, robotId);

                    identifiables.Add(robot);
                }
            }
            
            string targetEndOfId = Console.ReadLine();

            identifiables = identifiables.Where(i => i.Id.EndsWith(targetEndOfId)).ToList();

            foreach (IIdentifiable identifialble in identifiables)
            {
                Console.WriteLine(identifialble.Id);
            }
        }
    }
}
