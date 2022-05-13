namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int DefaultComfort = 5;
        private const decimal DefaultPrice = 10;

        public Plant() 
            : base(DefaultComfort, DefaultPrice)
        {
        }
    }
}
