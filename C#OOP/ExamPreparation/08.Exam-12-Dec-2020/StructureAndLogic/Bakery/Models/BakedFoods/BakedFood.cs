using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities;
using Bakery.Utilities.Messages;
using System;

namespace Bakery.Models.BakedFoods
{
    public abstract class BakedFood : IBakedFood
    {
        private const int MinValue = 0;

        private string name;
        private int portion;
        private decimal price;

        protected BakedFood(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowsExceptionIfParameterIsNullOrWhiteSpace(value, ExceptionMessages.InvalidName);

                this.name = value;
            }
        }

        public int Portion
        {
            get => this.portion;
            private set
            {
                Validator.ThrowsExceptionWhenParameterIsEqualOrLessThanTheGivenBase(value, MinValue, ExceptionMessages.InvalidPortion);

                this.portion = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                Validator.ThrowsExceptionWhenParameterIsEqualOrLessThanTheGivenBase(value, MinValue, ExceptionMessages.InvalidPrice);

                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.Portion}g - {this.Price:F2}";
        }
    }
}
