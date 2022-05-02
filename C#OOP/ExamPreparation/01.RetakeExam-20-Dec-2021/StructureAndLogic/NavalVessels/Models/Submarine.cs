using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double DefaultArmorThickness = 200;
        private const bool DefaultSubmergeMode = false;
        private const double AdditionToMainWeaponCaliber = 40;
        private const double AdditionToSpeed = 4;

        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, DefaultArmorThickness)
        {
            this.SubmergeMode = DefaultSubmergeMode;
        }

        public bool SubmergeMode
        {
            get => this.submergeMode;
            private set 
            {
                this.submergeMode = value;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode)
            {
                this.SubmergeMode = false;
            }
            else
            {
                this.SubmergeMode = true;
            }

            if (this.SubmergeMode)
            {
                this.MainWeaponCaliber += AdditionToMainWeaponCaliber;
                this.Speed -= AdditionToSpeed;
            }
            else
            {
                this.MainWeaponCaliber -= AdditionToMainWeaponCaliber;
                this.Speed += AdditionToSpeed;
            }
        }

        public override void RepairVessel()
        {
            this.ArmorThickness = DefaultArmorThickness;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            if (this.SubmergeMode)
            {
                sb.AppendLine(" *Submerge mode: ON");
            }
            else
            {
                sb.AppendLine(" *Submerge mode: OFF");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
