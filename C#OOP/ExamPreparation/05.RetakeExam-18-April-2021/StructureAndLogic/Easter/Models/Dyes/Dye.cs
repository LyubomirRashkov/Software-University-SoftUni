using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private const int MinPower = 0;
        private const int RequiredPower = 10;

        private int power;

        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => this.power;
            private set
            {
                if (value < MinPower)
                {
                    value = MinPower;
                }

                this.power = value;
            }
        }

        public bool IsFinished() => this.Power == MinPower;

        public void Use()
        {
            this.Power -= RequiredPower;
        }
    }
}
