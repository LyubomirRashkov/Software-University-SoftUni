namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        private const int NumberOfProductsToAdd = 100;

        private IProductStock productStock;
        private Random rnd;

        [SetUp]
        public void Setup()
        {
            this.productStock = new ProductStock();
            this.rnd = new Random();
        }

        [Test]
        public void Count_ReturnsZero_WhenThereAreNoProductsInProductStock()
        {
            Assert.That(this.productStock.Count, Is.EqualTo(0));
        }

        [Test]
        public void Add_AddsProductToTheProductStock()
        {
            int countBeforeAdding = this.productStock.Count;

            IProduct product = new Product("Label", 100, 10);

            this.productStock.Add(product);

            Assert.That(this.productStock.Count, Is.EqualTo(countBeforeAdding + 1));
            Assert.That(this.productStock.Contains(product), Is.True);
        }

        [Test]
        public void Contains_ReturnsFalse_WhenSearchingProductIsNotInProductStock()
        {
            IProduct product = new Product("Label", 100, 10);

            this.productStock.Add(product);

            IProduct searchingProduct = new Product("FakeLabel", 100, 10);

            Assert.That(this.productStock.Contains(searchingProduct), Is.False);
        }

        [Test]
        public void Find_ThrowsException_WhenGivenIndexIsLessThanZero()
        {
            int index = -1;

            Assert.Throws<IndexOutOfRangeException>(() => this.productStock.Find(index));
        }

        [Test]
        public void Find_ThrowsException_WhenGivenIndexIsEqualToProductsCount()
        {
            int index = this.productStock.Count;

            Assert.Throws<IndexOutOfRangeException>(() => this.productStock.Find(index));
        }

        [Test]
        public void Find_ThrowsException_WhenGivenIndexIsGreaterThanProductCount()
        {
            int index = this.productStock.Count + 1;

            Assert.Throws<IndexOutOfRangeException>(() => this.productStock.Find(index));
        }

        [Test]
        public void Find_ReturnsTheProductAtTheGivenIndex_WhenIndexIsValid()
        {
            this.AddBulkOfProducts(NumberOfProductsToAdd);

            int index = this.rnd.Next(0, NumberOfProductsToAdd);

            IProduct expectedProduct = this.productStock[index];

            IProduct actualProduct = this.productStock.Find(index);

            Assert.That(expectedProduct, Is.EqualTo(actualProduct));
        }

        [Test]
        public void FindByLabel_ThrowsException_WhenThereIsNoProductWithTheGivenLabel()
        {
            this.AddBulkOfProducts(NumberOfProductsToAdd);

            string targetLabel = "FakeLabel";

            Assert.That(() => this.productStock.FindByLabel(targetLabel), Throws.ArgumentException);
        }

        [Test]
        public void FindByLabel_ReturnsTheProductWithTheGivenLabel_WhenItExists()
        {
            this.AddBulkOfProducts(NumberOfProductsToAdd);

            int addition = this.rnd.Next(0, NumberOfProductsToAdd);

            string targetLabel = $"Label{addition}";

            IProduct product = this.productStock.FindByLabel(targetLabel);

            Assert.That(product.Label, Is.EqualTo(targetLabel));
        }

        [Test]
        [TestCase(0, 99)]
        [TestCase(200, 299)]
        public void FindAllInPriceRange_ReturnsEmptyCollection_WhenThereAreNoProductsInTheGivenRange(decimal low, decimal high)
        {
            this.AddBulkOfProducts(NumberOfProductsToAdd);

            Assert.That(() => this.productStock.FindAllInPriceRange(low, high), Is.EquivalentTo(new List<IProduct>()));
        }

        [Test]
        public void FindAllInPriceRange_ReturnsFilteredAndSortedData()
        {
            this.AddBulkOfProducts(NumberOfProductsToAdd);

            decimal low = this.productStock.FirstOrDefault().Price + 10;
            decimal high = this.productStock.LastOrDefault().Price - 10;

            IEnumerable<IProduct> expected = this.productStock
                                                 .Where(p => p.Price >= low && p.Price <= high)
                                                 .OrderByDescending(p => p.Price);

            IEnumerable<IProduct> actual = this.productStock.FindAllInPriceRange(low, high);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void FindAllInPriceRange_ReturnsFilteredAndSortedData2()
        {
            this.AddBulkOfProducts(NumberOfProductsToAdd);

            decimal low = this.productStock.FirstOrDefault().Price + 10;
            decimal high = this.productStock.LastOrDefault().Price - 10;

            IEnumerable<IProduct> result = this.productStock.FindAllInPriceRange(low, high);

            decimal previousPrice = decimal.MaxValue;

            foreach (IProduct product in result)
            {
                Assert.That(product.Price, Is.GreaterThanOrEqualTo(low));
                Assert.That(product.Price, Is.LessThanOrEqualTo(high));

                Assert.That(product.Price, Is.LessThanOrEqualTo(previousPrice));

                previousPrice = product.Price;
            }
        }

        [Test]
        public void FindAllByPrice_ReturnsAnEmtpyCollection_WhenThereAreNoProductsWithTheGivenPrice()
        {
            this.AddBulkOfProducts(NumberOfProductsToAdd);

            decimal targetPrice = this.productStock.FirstOrDefault().Price / 2;

            IEnumerable<IProduct> result = this.productStock.FindAllByPrice(targetPrice);

            Assert.That(result, Is.EquivalentTo(new List<IProduct>()));
        }

        [Test]
        public void FindAllByPrice_ReturnsFilteredData_WhenThereAreProductsWithTheGivenPrice()
        {
            this.AddBulkOfProducts(NumberOfProductsToAdd);

            decimal targetPrice = this.productStock.FirstOrDefault().Price;

            IEnumerable<IProduct> expected = this.productStock.Where(p => p.Price == targetPrice);

            IEnumerable<IProduct> actual = this.productStock.FindAllByPrice(targetPrice);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void FindAllByPrice_ReturnsFilteredData2_WhenThereAreProductsWithTheGivenPrice()
        {
            this.AddBulkOfProducts(NumberOfProductsToAdd);

            decimal targetPrice = this.productStock.FirstOrDefault().Price;

            IEnumerable<IProduct> result = this.productStock.FindAllByPrice(targetPrice);

            foreach (IProduct product in result)
            {
                Assert.That(product.Price, Is.EqualTo(targetPrice));
            }
        }

        [Test]
        public void FindMostExpensiveProduct_ReturnsTheMostExpensiveProduct() 
        {
            this.AddBulkOfProducts(NumberOfProductsToAdd);

            IProduct mostExpensiveProduct = this.productStock.FindMostExpensiveProduct();

            foreach (IProduct product in this.productStock)
            {
                Assert.That(product.Price, Is.LessThanOrEqualTo(mostExpensiveProduct.Price));
            }
        }

        [Test]
        public void FindAllByQuantity_ReturnsAnEmptyCollection_WhenThereAreNoProductsWithTheGivenQuantity()
        {
            this.AddBulkOfProducts(NumberOfProductsToAdd);

            int targetQuantity = this.productStock.FirstOrDefault().Quantity / 2;

            IEnumerable<IProduct> result = this.productStock.FindAllByQuantity(targetQuantity);

            Assert.That(result, Is.EquivalentTo(new List<IProduct>()));
        }

        [Test]
        public void FindAllByQuantity_ReturnsFilteredData_WhenThereAreProductsWithTheGivenQuantity() 
        {
            this.AddBulkOfProducts(NumberOfProductsToAdd);

            int targetQuantity = this.productStock.FirstOrDefault().Quantity;

            IEnumerable<IProduct> expected = this.productStock.Where(p => p.Quantity == targetQuantity);

            IEnumerable<IProduct> actual = this.productStock.FindAllByQuantity(targetQuantity);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void FindAllByQuantity_ReturnsFilteredData2_WhenThereAreProductsWithTheGivenQuantity()
        {
            this.AddBulkOfProducts(NumberOfProductsToAdd);

            int targetQuantity = this.productStock.FirstOrDefault().Quantity;

            IEnumerable<IProduct> result = this.productStock.FindAllByQuantity(targetQuantity);

            foreach (IProduct product in result)
            {
                Assert.That(product.Quantity, Is.EqualTo(targetQuantity));
            }
        }

        private void AddBulkOfProducts(int numberOfProducts) 
        {
            for (int i = 0; i < numberOfProducts; i++)
            {
                string label = $"Label{i}";
                decimal price = i % 2 == 0 ? 100 : 100 + i;
                int quantity = i % 2 == 0 ? 10 : 10 + i;

                IProduct product = new Product(label, price, quantity);

                this.productStock.Add(product);
            }
        }
    }
}
