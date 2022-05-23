using OnlineShop.Common;
using OnlineShop.Common.Constants;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        protected Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get => this.id;
            private set
            {
                Validator.ThrowsExceptionWhenParameterIsLessThanOrEqualToZero(value, ExceptionMessages.InvalidProductId);

                this.id = value;
            }
        }

        public string Manufacturer
        {
            get => this.manufacturer;
            private set 
            {
                Validator.ThrowsExceptionWhenParameterIsNullOrWhiteSpace(value, ExceptionMessages.InvalidManufacturer);

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get => this.model;
            private set
            {
                Validator.ThrowsExceptionWhenParameterIsNullOrWhiteSpace(value, ExceptionMessages.InvalidModel);

                this.model = value;
            }
        }

        public virtual decimal Price
        {
            get => this.price;
            private set
            {
                Validator.ThrowsExceptionWhenParameterIsLessThanOrEqualToZero((double)value, ExceptionMessages.InvalidPrice);

                this.price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get => this.overallPerformance;
            private set
            {
                Validator.ThrowsExceptionWhenParameterIsLessThanOrEqualToZero(value, ExceptionMessages.InvalidOverallPerformance);

                this.overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return $"Overall Performance: {this.OverallPerformance:F2}. Price: {this.Price:F2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})";
        }
    }
}
