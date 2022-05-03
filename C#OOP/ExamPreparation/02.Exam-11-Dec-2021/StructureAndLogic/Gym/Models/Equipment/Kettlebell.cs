namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double DefaultWeight = 10_000;
        private const decimal DefaultPrice = 80;

        public Kettlebell() 
            : base(DefaultWeight, DefaultPrice)
        {
        }
    }
}
