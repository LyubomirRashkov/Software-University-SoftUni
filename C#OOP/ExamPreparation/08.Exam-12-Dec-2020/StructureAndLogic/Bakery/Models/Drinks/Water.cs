namespace Bakery.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal DefaultWaterPrice = 1.5M;

        public Water(string name, int portion, string brand) 
            : base(name, portion, DefaultWaterPrice, brand)
        {
        }
    }
}
