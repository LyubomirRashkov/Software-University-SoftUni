namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private const string PresentName = "Some present";
        private const double PresentMagic = 10;

        private Bag bag;
        private Present present;

        [SetUp]
        public void Setup()
        {
            this.bag = new Bag();
            this.present = new Present(PresentName, PresentMagic);
        }

        [Test]
        public void PresentConstructor_SetsPropertiesWithTheGivenParameters()
        {
            Present present = new Present(PresentName, PresentMagic);

            Assert.That(present.Name, Is.EqualTo(PresentName));
            Assert.That(present.Magic, Is.EqualTo(PresentMagic));
        }

        [Test]
        public void BagConstructor_CreatesEmptyCollection()
        {
            IReadOnlyCollection<Present> expected = new List<Present>();

            IReadOnlyCollection<Present> actual = this.bag.GetPresents();

            Assert.That(actual.Count, Is.Zero);
            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void Create_ThrowsException_WhenGivenParameterIsNull()
        {
            Assert.That(() => this.bag.Create(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Create_ThrowsException_WhenGivenPresentAlreadyExists()
        {
            this.bag.Create(this.present);

            Assert.That(() => this.bag.Create(this.present), Throws.InvalidOperationException);
        }

        [Test]
        public void Create_WorksCorrectly_WhenDataIsValid()
        {
            Assert.That(this.bag.GetPresents().Count, Is.Zero);

            string expected = $"Successfully added present {PresentName}.";

            string actual = this.bag.Create(this.present);

            Assert.That(this.bag.GetPresents().Count, Is.EqualTo(1));
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Remove_ReturnsTrue_WhenTheRemovalIsSuccessfull()
        {
            this.bag.Create(this.present);

            Assert.That(this.bag.GetPresents().Count, Is.EqualTo(1));

            Assert.That(this.bag.Remove(this.present), Is.True);
            Assert.That(this.bag.GetPresents().Count, Is.Zero);
        }

        [Test]
        public void Remove_ReturnsFalse_WhenTheRemovalIsNotSuccessfull()
        {
            this.bag.Create(this.present);

            Assert.That(this.bag.GetPresents().Count, Is.EqualTo(1));

            Present fakePresent = new Present("Fake present", -25);

            Assert.That(this.bag.Remove(fakePresent), Is.False);
            Assert.That(this.bag.GetPresents().Count, Is.EqualTo(1));
        }

        [Test]
        public void GetPresentWithLeastMagic_ReturnsTheCorrectPresent()
        {
            this.bag.Create(this.present);

            Present present2 = new Present(PresentName + "2", PresentMagic - 5);
            this.bag.Create(present2);

            Present present3 = new Present(PresentName + "3", PresentMagic - 10);
            this.bag.Create(present3);

            Present present4 = new Present(PresentName + "4", PresentMagic - 10);
            this.bag.Create(present4);

            Present returnedPresent = this.bag.GetPresentWithLeastMagic();

            Assert.That(present3, Is.EqualTo(returnedPresent));
        }

        [Test]
        public void GetPresentWithLeastMagic_ThrowsException_WhenThereIsNoPresentAdded()
        {
            Assert.That(() => this.bag.GetPresentWithLeastMagic(), Throws.InvalidOperationException);
        }

        [Test]
        public void GetPresent_ReturnsNull_WhenThereIsNotPresentWithTheGivenName()
        {
            this.bag.Create(this.present);

            Present returnedPresent = this.bag.GetPresent("Fake name");

            Assert.That(returnedPresent, Is.Null);
        }

        [Test]
        public void GetPresent_ReturnsTheCorrectPresent_WhenThereIsAPresentWithTheGivenName()
        {
            this.bag.Create(this.present);

            Present returnedPresent = this.bag.GetPresent(PresentName);

            Assert.That(returnedPresent, Is.EqualTo(this.present));
        }

        [Test]
        public void GetPresents_ReturnsACollectionWithThePresentsInTheBag()
        {
            List<Present> expected = new List<Present>();

            this.bag.Create(this.present);
            expected.Add(this.present);

            Present present2 = new Present(PresentName + "2", PresentMagic - 5);
            this.bag.Create(present2);
            expected.Add(present2);

            Present present3 = new Present(PresentName + "3", PresentMagic - 10);
            this.bag.Create(present3);
            expected.Add(present3);

            Present present4 = new Present(PresentName + "4", PresentMagic - 10);
            this.bag.Create(present4);
            expected.Add(present4);

            IReadOnlyCollection<Present> actual = this.bag.GetPresents();

            Assert.That(expected, Is.EquivalentTo(actual));
        }
    }
}
