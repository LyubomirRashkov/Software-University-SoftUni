using _07.MilitaryElite.Enums;
using _07.MilitaryElite.Interfaces;
using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;

namespace _07.MilitaryElite
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, ISoldier> soldiersById = new Dictionary<string, ISoldier>();

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "End")
                {
                    break;
                }

                string[] inputInfo = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string inputType = inputInfo[0];
                string inputId = inputInfo[1];
                string inputFirstName = inputInfo[2];
                string inputLastName = inputInfo[3];

                if (inputType == nameof(Private))
                {
                    decimal inputSalary = decimal.Parse(inputInfo[4]);

                    IPrivate @private = new Private(inputId, inputFirstName, inputLastName, inputSalary);

                    soldiersById.Add(inputId, @private);
                }
                else if (inputType == nameof(LieutenantGeneral))
                {
                    decimal inputSalary = decimal.Parse(inputInfo[4]);

                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(inputId, inputFirstName, inputLastName, inputSalary);

                    for (int i = 5; i < inputInfo.Length; i++)
                    {
                        string currentId = inputInfo[i];

                        lieutenantGeneral.AddPrivate((IPrivate)(soldiersById[currentId]));
                    }

                    soldiersById.Add(inputId, lieutenantGeneral);
                }
                else if (inputType == nameof(Engineer))
                {
                    decimal inputSalary = decimal.Parse(inputInfo[4]);

                    bool isInputCorpsValid = Enum.TryParse(inputInfo[5], out Corps inputCorps);

                    if (!isInputCorpsValid)
                    {
                        continue;
                    }

                    IEngineer engineer = new Engineer(inputId, inputFirstName, inputLastName, inputSalary, inputCorps);

                    for (int i = 6; i < inputInfo.Length; i += 2)
                    {
                        string repairPartName = inputInfo[i];
                        int repairHoursWorked = int.Parse(inputInfo[i + 1]);

                        IRepair repair = new Repair(repairPartName, repairHoursWorked);

                        engineer.AddRepair(repair);
                    }

                    soldiersById.Add(inputId, engineer);
                }
                else if (inputType == nameof(Commando))
                {
                    decimal inputSalary = decimal.Parse(inputInfo[4]);

                    bool isInputCorpsValid = Enum.TryParse(inputInfo[5], out Corps inputCorps);

                    if (!isInputCorpsValid)
                    {
                        continue;
                    }

                    ICommando commando = new Commando(inputId, inputFirstName, inputLastName, inputSalary, inputCorps);

                    for (int i = 6; i < inputInfo.Length; i += 2)
                    {
                        string inputMissionName = inputInfo[i];

                        bool isInputMissionStateValid = Enum.TryParse(inputInfo[i + 1], out MissionState inputMissionState);

                        if (!isInputMissionStateValid)
                        {
                            continue;
                        }

                        IMission mission = new Mission(inputMissionName, inputMissionState);

                        commando.AddMission(mission);
                    }

                    soldiersById.Add(inputId, commando);
                }
                else if (inputType == nameof(Spy))
                {
                    int inputCodeNumber = int.Parse(inputInfo[4]);

                    ISpy spy = new Spy(inputId, inputFirstName, inputLastName, inputCodeNumber);

                    soldiersById.Add(inputId, spy);
                }
            }

            foreach (var kvp in soldiersById)
            {
                Console.WriteLine(kvp.Value);
            }
        }
    }
}
