using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products;

        public ProductStock()
        {
            products = new List<IProduct>();
        }

        public int Count => this.products.Count;

        public IProduct this[int index] 
        {
            get
            {
                if (index < 0 || index >= this.products.Count) 
                {
                    throw new IndexOutOfRangeException();
                }

                return this.products[index];
            }
            set 
            {
                if (index < 0 || index >= this.products.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                this.products[index] = value;
            }
        }

        public void Add(IProduct product)
        {
            this.products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            IProduct targetProduct = this.products.FirstOrDefault(p => p.Label == product.Label);

            if (targetProduct == null)
            {
                return false;
            }

            return true;
        }

        public IProduct Find(int index)
        {
            return this[index];
        }

        public IProduct FindByLabel(string label)
        {
            IProduct product = this.products.FirstOrDefault(p => p.Label == label);

            if (product == null)
            {
                throw new ArgumentException();
            }

            return product;
        }

        public IEnumerable<IProduct> FindAllInPriceRange(decimal lo, decimal hi)
        {
            return this.products
                       .Where(p => p.Price >= lo && p.Price <= hi)
                       .OrderByDescending(p => p.Price);
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return this.products
                       .Where(p => p.Price == price);
        }

        public IProduct FindMostExpensiveProduct()
        {
            return this.products.OrderByDescending(p => p.Price).FirstOrDefault();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return this.products.Where(p => p.Quantity == quantity);
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (IProduct product in products)
            {
                yield return product;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
