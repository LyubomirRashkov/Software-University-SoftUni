namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private const double InitialFuelAmount = 0.0;

        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Make", "Model", 10.0, 100.0);
        }

        [Test]
        [TestCase(null, "Model", 10.0, 100.0)]
        [TestCase("", "Model", 10.0, 100.0)]
        [TestCase("Make", null, 10.0, 100.0)]
        [TestCase("Make", "", 10.0, 100.0)]
        [TestCase("Make", "Model", 0, 100.0)]
        [TestCase("Make", "Model", -10.0, 100.0)]
        [TestCase("Make", "Model", 10.0, 0)]
        [TestCase("Make", "Model", 10.0, -100.0)]
        public void Ctor_ThrowsException_WhenAParameterIsInvalid
                                         (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.That(() => new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException);
        }

        [Test]
        public void Ctor_SetsValuesToGivenParameters_WhenValuesAreValid()
        {
            string make = "Make";
            string model = "Model";
            double fuelConsumption = 10.0;
            double fuelCapacity = 100.0;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
            Assert.That(car.FuelAmount, Is.EqualTo(InitialFuelAmount));
        }

        [Test]
        [TestCase(0.0)]
        [TestCase(-10.0)]
        public void Refuel_ThrowsException_WhenGivenParameterIsEqualToOrLessThanZero(double fuelToRefuel)
        {
            Assert.That(() => this.car.Refuel(fuelToRefuel), Throws.ArgumentException, "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void Refuel_IncreasesFuelAmount_WithGivenParameter_WhenParameterIsValidAndThereIsEnoughFuelCapacity()
        {
            double fuelToRefuel = this.car.FuelCapacity / 2;

            this.car.Refuel(fuelToRefuel);

            Assert.That(this.car.FuelAmount, Is.EqualTo(fuelToRefuel));
        }

        [Test]
        public void Refuel_IncreasesFuelAmountToFuelCapacity_WhenGivenParameterIsValidButThereIsNotEnoughFuelCapacity()
        {
            double fuelToRefuel = this.car.FuelCapacity * 2;

            this.car.Refuel(fuelToRefuel);

            Assert.That(this.car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void Drive_ThrowsException_WhenRequiredFuelIsMoreThanFuelAmount() 
        {
            double fuelToRefuel = this.car.FuelCapacity / 2;
            this.car.Refuel(fuelToRefuel);

            double distance = (this.car.FuelAmount * this.car.FuelConsumption) + 1;

            Assert.That(() => this.car.Drive(distance), Throws.InvalidOperationException, "You don't have enough fuel to drive!");
        }

        [Test]
        public void Drive_ReducesFuelAmountToZero_WhenRequredFuelIsEqualToFuelAmount() 
        {
            double fuelToRefuel = this.car.FuelCapacity / 2;
            this.car.Refuel(fuelToRefuel);

            double distance = (this.car.FuelAmount * this.car.FuelConsumption);

            this.car.Drive(distance);

            Assert.That(this.car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void Drive_ReducesFuelAmountWithRequiredFuel_WhenRequiredFuelIsLessThanFuelAmount() 
        {
            double fuelToRefuel = this.car.FuelCapacity / 2;
            this.car.Refuel(fuelToRefuel);
            double fuelAmountBeforeDrive = this.car.FuelAmount;

            double distance = (this.car.FuelAmount * this.car.FuelConsumption) / 2;

            this.car.Drive(distance);
            double fuelAmountAfterDrive = this.car.FuelAmount;

            Assert.That(fuelAmountBeforeDrive, Is.EqualTo(fuelAmountAfterDrive + (distance * (this.car.FuelConsumption / 100))));
        }
    }
}