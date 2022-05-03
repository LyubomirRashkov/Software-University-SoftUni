namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double DefaultWeight = 227;
        private const decimal DefaultPrice = 120;

        public BoxingGloves() 
            : base(DefaultWeight, DefaultPrice)
        {
        }
    }
}
