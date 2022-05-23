namespace OnlineShop.Models.Products.Components
{
    public abstract class Component : Product, IComponent
    {
        private int generation;

        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.Generation = generation;
        }

        public int Generation
        {
            get => this.generation;
            private set => this.generation = value;
        }

        public override string ToString()
        {
            return (base.ToString() + $" Generation: {this.Generation}");
        }
    }
}
