using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private IDictionary<string, ICaptain> captainsByName;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captainsByName = new Dictionary<string, ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (!this.captainsByName.ContainsKey(selectedCaptainName))
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            ICaptain captain = this.captainsByName[selectedCaptainName];

            if (this.vessels.FindByName(selectedVesselName) == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            IVessel vessel = this.vessels.FindByName(selectedVesselName);

            if (vessel.Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            captain.AddVessel(vessel);
            vessel.Captain = captain;

            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = this.vessels.FindByName(attackingVesselName);

            if (attacker == null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            IVessel defender = this.vessels.FindByName(defendingVesselName);

            if (defender == null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attacker.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }

            if (defender.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, 
                                                                          defender.ArmorThickness);
        }

        public string CaptainReport(string captainFullName) => this.captainsByName[captainFullName].Report();

        public string HireCaptain(string fullName)
        {
            if (this.captainsByName.ContainsKey(fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            ICaptain captain = new Captain(fullName);

            this.captainsByName.Add(fullName, captain);

            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (this.vessels.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            if (vesselType != nameof(Battleship) && vesselType != nameof(Submarine))
            {
                return OutputMessages.InvalidVesselType;
            }

            IVessel vessel = this.CreateVessel(vesselType, name, mainWeaponCaliber, speed);

            this.vessels.Add(vessel);

            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();

            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vessel.GetType().Name == nameof(Battleship))
            {
                IBattleship battleship = this.vessels.FindByName(vesselName) as Battleship;

                battleship.ToggleSonarMode();

                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }

            ISubmarine submarine = this.vessels.FindByName(vesselName) as Submarine;

            submarine.ToggleSubmergeMode();

            return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
        }

        public string VesselReport(string vesselName) => this.vessels.FindByName(vesselName).ToString();

        private IVessel CreateVessel(string vesselType, string name, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = null;

            if (vesselType == nameof(Battleship))
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }

            return vessel;
        }
    }
}
