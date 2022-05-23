namespace OnlineShop.Models.Products.Peripherals
{
    public abstract class Peripheral : Product, IPeripheral
    {
        private string connectionType;

        protected Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.ConnectionType = connectionType;
        }

        public string ConnectionType
        {
            get => this.connectionType;
            private set => this.connectionType = value;
        }

        public override string ToString()
        {
            return (base.ToString() + $" Connection Type: {this.ConnectionType}");
        }
    }
}
