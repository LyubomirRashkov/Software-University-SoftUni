using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private IDictionary<string, IGym> gymsByName;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gymsByName = new Dictionary<string, IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = this.gymsByName[gymName];

            if (athleteType != nameof(Boxer) && athleteType != nameof(Weightlifter))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            IAthlete athlete = this.CreateAthlete(athleteType, athleteName, motivation, numberOfMedals);

            if (athleteType == nameof(Boxer))
            {
                Boxer boxer = athlete as Boxer;

                if (boxer.TrainingHall != gym.GetType().Name)
                {
                    return OutputMessages.InappropriateGym;
                }
            }
            else
            {
                Weightlifter weightlifter = athlete as Weightlifter;

                if (weightlifter.TrainingHall != gym.GetType().Name)
                {
                    return OutputMessages.InappropriateGym;
                }
            }

            gym.AddAthlete(athlete);

            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != nameof(BoxingGloves) && equipmentType != nameof(Kettlebell))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            IEquipment equipment = this.CreateEquipment(equipmentType);

            this.equipment.Add(equipment);

            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != nameof(BoxingGym) && gymType != nameof(WeightliftingGym))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            IGym gym = this.CreateGym(gymType, gymName);

            this.gymsByName.Add(gym.Name, gym);

            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gymsByName[gymName];

            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:F2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipment.FindByType(equipmentType);

            if (equipment == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            this.gymsByName[gymName].AddEquipment(equipment);
            this.equipment.Remove(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gymsByName[gymName];

            gym.Exercise();

            return String.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var kvp in this.gymsByName)
            {
                sb.AppendLine(kvp.Value.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }

        private IGym CreateGym(string gymType, string gymName)
        {
            IGym gym = null;

            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else
            {
                gym = new WeightliftingGym(gymName);
            }

            return gym;
        }

        private IEquipment CreateEquipment(string equipmentType)
        {
            IEquipment equipment = null;

            if (equipmentType == nameof(BoxingGloves))
            {
                equipment = new BoxingGloves();
            }
            else
            {
                equipment = new Kettlebell();
            }

            return equipment;
        }

        private IAthlete CreateAthlete(string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;

            if (athleteType == nameof(Boxer))
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }

            return athlete;
        }
    }
}
