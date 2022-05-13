namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int DefaultCapacity = 50;

        public FreshwaterAquarium(string name) 
            : base(name, DefaultCapacity)
        {
        }
    }
}
