using NUnit.Framework;
using System.Linq;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private const int MinParticipants = 2;

        private RaceEntry raceEnty;
        private UnitCar car1;
        private UnitCar car2;

        [SetUp]
        public void Setup()
        {
            this.raceEnty = new RaceEntry();
            this.car1 = new UnitCar("Ford", 150, 2000);
            this.car2 = new UnitCar("Opel", 120, 1800);
        }

        [Test]
        public void Constructor_CreatesEntityWithEmptyCollection()
        {
            RaceEntry rE = new RaceEntry();

            Assert.That(rE.Counter, Is.Zero);
        }

        [Test]
        public void AddDriver_ThrowsException_WhenAddingADriverThatIsNull()
        {
            UnitDriver driver = null;

            Assert.That(() => this.raceEnty.AddDriver(driver), Throws.InvalidOperationException);
        }

        [Test]
        public void AddDriver_ThrowsException_WhenAddingAnExistingDriver()
        {
            string driverName = "Driver";

            UnitDriver driver1 = new UnitDriver(driverName, this.car1);

            this.raceEnty.AddDriver(driver1);

            UnitDriver driver2 = new UnitDriver(driverName, this.car2);

            Assert.That(() => this.raceEnty.AddDriver(driver2), Throws.InvalidOperationException);
        }

        [Test]
        public void AddDriver_WorksCorrectly_WhenDataIsValid()
        {
            Assert.That(this.raceEnty.Counter, Is.Zero);

            UnitDriver driver = new UnitDriver("Driver", this.car1);

            this.raceEnty.AddDriver(driver);

            Assert.That(this.raceEnty.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddDriver_ReturnsCorrectString()
        {
            string driverName = "Driver";

            UnitDriver driver = new UnitDriver(driverName, this.car1);

            string expected = $"Driver {driverName} added in race.";

            string actual = this.raceEnty.AddDriver(driver);

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void CalculateAverageHorsePower_ThrowsException_WhenTheCountIsLessThatMinParticipants()
        {
            UnitDriver driver = new UnitDriver("Driver", car1);

            this.raceEnty.AddDriver(driver);

            Assert.That(() => this.raceEnty.CalculateAverageHorsePower(), Throws.InvalidOperationException);
        }

        [Test]
        public void CalculateAverageHorsePower_ReturnsTheCorrectResult()
        {
            int[] horsePowers = new int[] { 100, 120, 150 };

            double expected = horsePowers.Average();

            UnitDriver driver1 = new UnitDriver("Driver1", new UnitCar("Ford", horsePowers[0], 1500));
            this.raceEnty.AddDriver(driver1);

            UnitDriver driver2 = new UnitDriver("Driver2", new UnitCar("Opel", horsePowers[1], 1800));
            this.raceEnty.AddDriver(driver2);

            UnitDriver driver3 = new UnitDriver("Driver3", new UnitCar("Volkswagen", horsePowers[2], 2000));
            this.raceEnty.AddDriver(driver3);

            double actual = this.raceEnty.CalculateAverageHorsePower();

            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}