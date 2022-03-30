namespace _03.Raiding
{
    public abstract class BaseHero
    {
        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        protected string Name { get; private set; }

        public int Power { get; private set; }

        public abstract string CastAbility();
    }
}
