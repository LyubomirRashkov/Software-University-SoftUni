namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int DefaultCapacity = 25;

        public SaltwaterAquarium(string name) 
            : base(name, DefaultCapacity)
        {
        }
    }
}
