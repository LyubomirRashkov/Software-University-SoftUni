namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    public class AquariumsTests
    {
        private const string AquariumName = "Some aquarium";
        private const int AquariumCapacity = 2;
        private const string FishName = "Some fish";

        private Aquarium aquarium;
        private Fish fish;

        [SetUp]
        public void Setup()
        {
            this.aquarium = new Aquarium(AquariumName, AquariumCapacity);
            this.fish = new Fish(FishName);
        }

        [Test]
        public void FishConstructor_WorksCorrectly()
        {
            Fish fish = new Fish(FishName);

            Assert.That(fish.Name, Is.EqualTo(FishName));
            Assert.That(fish.Available, Is.True);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void AquariumConstructor_ThrowsException_WhenGivenNameIsNullOrEmpty(string name)
        {
            Assert.That(() => new Aquarium(name, AquariumCapacity), Throws.ArgumentNullException);
        }

        [Test]
        public void AquariumConstructor_ThrowsException_WhenGivenCapacityIsLessThanZero()
        {
            int invalidCapacity = -10;

            Assert.That(() => new Aquarium(AquariumName, invalidCapacity), Throws.ArgumentException);
        }

        [Test]
        public void AquariumConstructor_WorksCorrectly_WhenDataIsValid()
        {
            Assert.That(this.aquarium.Name, Is.EqualTo(AquariumName));
            Assert.That(this.aquarium.Capacity, Is.EqualTo(AquariumCapacity));
            Assert.That(this.aquarium.Count, Is.Zero);
        }

        [Test]
        public void Add_WorksCorrectly_WhenAquariumIsNotFull()
        {
            Assert.That(this.aquarium.Count, Is.Zero);

            this.aquarium.Add(this.fish);

            Assert.That(this.aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_ThrowsException_WhenAquariumIsFull()
        {
            string fish1Name = "Name 1";
            Fish fish1 = new Fish(fish1Name);
            this.aquarium.Add(fish1);

            string fish2Name = "Name 2";
            Fish fish2 = new Fish(fish2Name);
            this.aquarium.Add(fish2);

            string fish3Name = "Name 3";
            Fish fish3 = new Fish(fish3Name);

            Assert.That(() => this.aquarium.Add(fish3), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveFish_ThrowsException_WhenThereIsNotAFishWithTheGivenName()
        {
            this.aquarium.Add(this.fish);

            Assert.That(() => this.aquarium.RemoveFish("Fake name"), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveFish_WorksCorrectly_WhenThereIsAFishWithTheGivenName()
        {
            this.aquarium.Add(this.fish);

            Assert.That(this.aquarium.Count, Is.EqualTo(1));

            this.aquarium.RemoveFish(FishName);

            Assert.That(this.aquarium.Count, Is.Zero);
        }

        [Test]
        public void SellFish_ThrowsException_WhenThereIsNotAFishWithTheGivenName()
        {
            this.aquarium.Add(this.fish);

            Assert.That(() => this.aquarium.SellFish("Fake name"), Throws.InvalidOperationException);
        }

        [Test]
        public void SellFish_WorksCorrectly_WhenThereIsAFishWithTheGivenName()
        {
            this.aquarium.Add(this.fish);

            Fish expected = this.fish;

            Fish actual = this.aquarium.SellFish(FishName);

            Assert.That(expected, Is.EqualTo(actual));
            Assert.That(this.fish.Available, Is.False);
        }

        [Test]
        public void Report_ReturnsTheCorrectString()
        {
            List<string> fishNames = new List<string>();

            string fish1Name = "Name 1";
            fishNames.Add(fish1Name);
            Fish fish1 = new Fish(fish1Name);
            this.aquarium.Add(fish1);

            string fish2Name = "Name 2";
            fishNames.Add(fish2Name);
            Fish fish2 = new Fish(fish2Name);
            this.aquarium.Add(fish2);

            string expected = $"Fish available at {AquariumName}: {string.Join(", ", fishNames)}";

            string actual = this.aquarium.Report();

            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}
