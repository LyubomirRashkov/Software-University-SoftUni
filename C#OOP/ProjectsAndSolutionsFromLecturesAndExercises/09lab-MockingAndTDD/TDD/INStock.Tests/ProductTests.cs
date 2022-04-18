namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Ctor_CreatesInstance_WithTheGivenParameters()
        {
            string label = "Label";
            decimal price = 100;
            int quantity = 10;

            IProduct product = new Product(label, price, quantity);

            Assert.That(product.Label, Is.EqualTo(label));
            Assert.That(product.Price, Is.EqualTo(price));
            Assert.That(product.Quantity, Is.EqualTo(quantity));
        }

        [Test]
        [TestCase("Label1", 101, 10, "Label2", 100, 10, 1)]
        [TestCase("Label1", 100, 11, "Label2", 100, 10, 1)]
        [TestCase("Label1", 100, 10, "Label2", 100, 10, 0)]
        [TestCase("Label1", 99, 10, "Label2", 100, 10, -1)]
        [TestCase("Label1", 100, 9, "Label2", 100, 10, -1)]
        public void CompareTo_ReturnsExpectedResult
               (string label1, decimal price1, int quantity1, string label2, decimal price2, int quantity2, int expectedresult) 
        {
            IProduct product1 = new Product(label1, price1, quantity1);

            IProduct product2 = new Product(label2, price2, quantity2);

            Assert.That(product1.CompareTo(product2), Is.EqualTo(expectedresult));
        }
    }
}