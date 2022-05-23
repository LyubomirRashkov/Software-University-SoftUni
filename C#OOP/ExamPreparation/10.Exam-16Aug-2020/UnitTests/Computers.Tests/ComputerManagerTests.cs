using NUnit.Framework;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        private const string Manufacturer = "Some manufacturer";
        private const string Model = "Some model";
        private const decimal Price = 1000;
        private const string FakeManufacturer = "Fake manufacturer";
        private const string FakeModel = "Fake model";

        private ComputerManager cm;
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            this.cm = new ComputerManager();
            this.computer = new Computer(Manufacturer, Model, Price);
        }

        [Test]
        public void Constructor_CreatesAnEmptyCollection()
        {
            Assert.That(this.cm.Computers.Count, Is.Zero);
        }

        [Test]
        public void Count_ReturnsTheCountOfComputersInTheCollection()
        {
            Assert.That(this.cm.Count, Is.Zero);
        }

        [Test]
        public void AddComputer_ThrowsException_WhenTheGivenComputerIsNull()
        {
            Assert.That(() => this.cm.AddComputer(null), Throws.ArgumentNullException);
        }

        [Test]
        public void AddComputer_WorksCorrectly_WhenDataIsValid()
        {
            Assert.That(this.cm.Count, Is.Zero);

            this.cm.AddComputer(this.computer);

            Assert.That(this.cm.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddComputer_ThrowsException_WhenThereIsAComputerWithTheGivenManufacttureAndModelInTheCollection()
        {
            this.cm.AddComputer(this.computer);

            Assert.That(() => this.cm.AddComputer(this.computer), Throws.ArgumentException);
        }

        [Test]
        public void GetComputer_ThrowsException_WhenGivenManufacturerIsNull()
        {
            this.cm.AddComputer(this.computer);

            Assert.That(() => this.cm.GetComputer(null, Model), Throws.ArgumentNullException);
        }

        [Test]
        public void GetComputer_ThrowsException_WhenGivenModelIsNull()
        {
            this.cm.AddComputer(this.computer);

            Assert.That(() => this.cm.GetComputer(Manufacturer, null), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase(FakeManufacturer, Model)]
        [TestCase(Manufacturer, FakeModel)]
        [TestCase(FakeManufacturer, FakeModel)]
        public void Getcomputer_ThrowsException_WhenThereIsNotAComputerWithTheGivenManufacturerAndModel(string manufacturer, string model)
        {
            this.cm.AddComputer(this.computer);

            Assert.That(() => this.cm.GetComputer(manufacturer, model), Throws.ArgumentException);
        }

        [Test]
        public void GetComputer_ReturnsTheCorrectComputer_WhenDataIsValid()
        {
            this.cm.AddComputer(this.computer);

            Computer returnedComputer = this.cm.GetComputer(Manufacturer, Model);

            Assert.That(this.computer, Is.EqualTo(returnedComputer));
        }

        [Test]
        public void RemoveComputer_ThrowsException_WhenGivenManufacturerIsNull()
        {
            this.cm.AddComputer(this.computer);

            Assert.That(() => this.cm.RemoveComputer(null, Model), Throws.ArgumentNullException);
        }

        [Test]
        public void RemoveComputer_ThrowsException_WhenGivenModelIsNull()
        {
            this.cm.AddComputer(this.computer);

            Assert.That(() => this.cm.RemoveComputer(Manufacturer, null), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase(FakeManufacturer, Model)]
        [TestCase(Manufacturer, FakeModel)]
        [TestCase(FakeManufacturer, FakeModel)]
        public void RemoveComputer_ThrowsException_WhenThereIsNotAComputerWithTheGivenManufacturerAndModel(string manufacturer, string model)
        {
            this.cm.AddComputer(this.computer);

            Assert.That(() => this.cm.RemoveComputer(manufacturer, model), Throws.ArgumentException);
        }

        [Test]
        public void RemoveComputer_WorksCorrectly_WhenDataIsValid()
        {
            this.cm.AddComputer(this.computer);

            Assert.That(this.cm.Count, Is.EqualTo(1));

            Computer removedComputer = this.cm.RemoveComputer(Manufacturer,Model);

            Assert.That(this.cm.Count, Is.Zero);
            Assert.That(this.computer, Is.EqualTo(removedComputer));
        }

        [Test]
        public void GetComputersByManufacturer_ThrowsException_WhenTheGivenManufacturerIsNull()
        {
            Assert.That(() => this.cm.GetComputersByManufacturer(null), Throws.ArgumentNullException);
        }

        [Test]
        public void GetComputersByManufacturer_WorksCorrectly_WhenDataIsValid()
        {
            this.cm.AddComputer(this.computer);

            Computer computer2 = new Computer(Manufacturer, Model + "2", Price + 100);
            this.cm.AddComputer(computer2);

            Computer computer3 = new Computer(Manufacturer + "2", Model + "5", Price + 200);
            this.cm.AddComputer(computer3);

            ICollection<Computer> expected = new List<Computer>() 
            {
                this.computer,
                computer2
            };

            ICollection<Computer> actual = this.cm.GetComputersByManufacturer(Manufacturer);

            Assert.That(expected, Is.EquivalentTo(actual));
        }
    }
}