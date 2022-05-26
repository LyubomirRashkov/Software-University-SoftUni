using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private const int Capacity = 2;
        private const string ModelName = "Some model";
        private const int Battery = 100;
        private const string FakeModel = "Fake model";
        private const int BatteryUsage = 10;

        private Shop shop;
        private Smartphone smartphone;

        [SetUp]
        public void Setup()
        {
            this.shop = new Shop(Capacity);
            this.smartphone = new Smartphone(ModelName, Battery);
        }

        [Test]
        public void Constructor_ThrowsException_WhenGivenCapacityIsLessThanZero()
        {
            Assert.That(() => new Shop(-5), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_WorksCorrectly_WhenDataIsValid()
        {
            Assert.That(this.shop.Capacity, Is.EqualTo(Capacity));
            Assert.That(this.shop, Is.Not.Null);
            Assert.That(this.shop.Count, Is.Zero);
        }

        [Test]
        public void Add_WorksCorrectly_WhenDataIsValid()
        {
            Assert.That(this.shop.Count, Is.Zero);

            this.shop.Add(this.smartphone);

            Assert.That(this.shop.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddingAPhoneWhichIsAlreadyInTheShop()
        {
            this.shop.Add(this.smartphone);

            Smartphone newSmartphone = new Smartphone(ModelName, Battery + 10);

            Assert.That(() => this.shop.Add(newSmartphone), Throws.InvalidOperationException);
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsReached()
        {
            this.shop.Add(this.smartphone);

            Smartphone newSmartphone = new Smartphone("New model", 150);
            this.shop.Add(newSmartphone);

            Smartphone newSmartphone2 = new Smartphone("New model2", 250);

            Assert.That(() => this.shop.Add(newSmartphone2), Throws.InvalidOperationException);
        }

        [Test]
        public void Remove_ThrowsException_WhenThereIsNotAPhoneWithTheGivenModel()
        {
            this.shop.Add(this.smartphone);

            Assert.That(() => this.shop.Remove(FakeModel), Throws.InvalidOperationException);
        }

        [Test]
        public void Remove_WorksCorrectly_WhenDataIsValid()
        {
            this.shop.Add(this.smartphone);

            Assert.That(this.shop.Count, Is.EqualTo(1));

            this.shop.Remove(ModelName);

            Assert.That(this.shop.Count, Is.Zero);
        }

        [Test]
        public void TestPhone_ThrowsException_WhenCallingANonExistingPhone()
        {
            this.shop.Add(this.smartphone);

            Assert.That(() => this.shop.TestPhone(FakeModel, BatteryUsage), Throws.InvalidOperationException);
        }

        [Test]
        public void TestPhone_ThrowsException_WhenCallingAPhoneWithCurrentBatteryLessThanTheBatteryUsage()
        {
            this.shop.Add(this.smartphone);

            Assert.That(() => this.shop.TestPhone(ModelName, Battery + BatteryUsage), Throws.InvalidOperationException);
        }

        [Test]
        public void TestPhone_WorksCorrectly_WhenDataIsValid()
        {
            this.shop.Add(this.smartphone);

            int batteryBeforeTesting = this.smartphone.CurrentBateryCharge;

            this.shop.TestPhone(ModelName, BatteryUsage);

            Assert.That(this.smartphone.CurrentBateryCharge, Is.EqualTo(batteryBeforeTesting - BatteryUsage));
        }

        [Test]
        public void ChargePhone_ThrowsException_WhenCallingANonExistingPhone()
        {
            this.shop.Add(this.smartphone);

            Assert.That(() => this.shop.ChargePhone(FakeModel), Throws.InvalidOperationException);
        }

        [Test]
        public void ChargePhone_WorksCorrectly_WhenDataIsValid()
        {
            this.shop.Add(this.smartphone);

            int batteryBeforeTesting = this.smartphone.CurrentBateryCharge;

            this.shop.TestPhone(ModelName, BatteryUsage);

            Assert.That(this.smartphone.CurrentBateryCharge, Is.EqualTo(batteryBeforeTesting - BatteryUsage));

            this.shop.ChargePhone(ModelName);

            Assert.That(this.smartphone.CurrentBateryCharge, Is.EqualTo(this.smartphone.MaximumBatteryCharge));
        }
    }
}