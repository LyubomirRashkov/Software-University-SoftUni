using INStock.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace INStock
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            this.label = label;
            this.price = price;
            this.quantity = quantity;
        }

        public string Label => this.label;

        public decimal Price => this.price;

        public int Quantity => this.quantity;

        public int CompareTo([AllowNull] IProduct other)
        {
            int result = this.Price.CompareTo(other.Price);

            if (result == 0)
            {
                result = this.Quantity.CompareTo(other.Quantity);
            }

            return result;
        }
    }
}
