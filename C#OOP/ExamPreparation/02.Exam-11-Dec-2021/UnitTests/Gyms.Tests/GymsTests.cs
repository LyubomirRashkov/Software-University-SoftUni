using NUnit.Framework;
using System.Collections.Generic;

namespace Gyms.Tests
{
    public class GymsTests
    {
        private const string GymName = "GymName";
        private const int GymSize = 1;
        private const string AthleteName = "Some athlete";

        private Gym gym;

        [SetUp]
        public void Setup()
        {
            this.gym = new Gym(GymName, GymSize);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Constructor_ThrowsException_WhenNameIsNullOrEmpty(string name)
        {
            Assert.That(() => new Gym(name, GymSize), Throws.ArgumentNullException);
        }

        [Test]
        public void Constructor_ThrowsException_WhenSizeIsLessThanZero()
        {
            int invalidSize = -10;

            Assert.That(() => new Gym(GymName, invalidSize), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_WorksCorrectly_WhenDataIsValid()
        {
            Assert.That(this.gym.Name, Is.EqualTo(GymName));
            Assert.That(this.gym.Capacity, Is.EqualTo(GymSize));
            Assert.That(this.gym.Count, Is.Zero);
        }

        [Test]
        public void AddAthlete_WorksCorrectly_WhenDataIsValid()
        {
            Assert.That(this.gym.Count, Is.Zero);

            Athlete athlete = new Athlete(AthleteName);

            this.gym.AddAthlete(athlete);

            Assert.That(this.gym.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddAthlete_ThorwsException_WhenTheGymIsFull()
        {
            Athlete athlete1 = new Athlete("Some athlete 1");

            this.gym.AddAthlete(athlete1);

            Athlete athlete2 = new Athlete("Some athlete 2");

            Assert.That(() => this.gym.AddAthlete(athlete2), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveAthlete_ThrowsException_WhenThereIsNotAthleteWithTheGivenName()
        {
            Athlete athlete = new Athlete(AthleteName);

            this.gym.AddAthlete(athlete);

            Assert.That(() => this.gym.RemoveAthlete("Fake Name"), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveAthlete_WorksCorrectly_WhenDataIsValid()
        {
            Athlete athlete = new Athlete(AthleteName);

            this.gym.AddAthlete(athlete);

            Assert.That(this.gym.Count, Is.EqualTo(1));

            this.gym.RemoveAthlete(AthleteName);

            Assert.That(this.gym.Count, Is.Zero);
        }

        [Test]
        public void InjureAthlete_ThrowsException_WhenThereIsNotAthleteWithTheGivenName()
        {
            Athlete athlete = new Athlete(AthleteName);

            this.gym.AddAthlete(athlete);

            Assert.That(() => this.gym.InjureAthlete("Fake Name"), Throws.InvalidOperationException);
        }

        [Test]
        public void InjureAthlete_WorksCorrectly_WhenDataIsValid()
        {
            Athlete athlete = new Athlete(AthleteName);

            this.gym.AddAthlete(athlete);

            Athlete returnedAthlete = this.gym.InjureAthlete(AthleteName);
            
            Assert.That(athlete.IsInjured, Is.True);

            Assert.That(athlete, Is.EqualTo(returnedAthlete));
        }

        [Test]
        public void Report_ReturnsTheCorrectString()
        {
            List<string> names = new List<string>();

            int gymSize = 3;

            Gym gym = new Gym(GymName, gymSize);

            string athlete1Name = "Name 1";

            Athlete athlete1 = new Athlete(athlete1Name);
            gym.AddAthlete(athlete1);
            names.Add(athlete1.FullName);

            string athlete2Name = "Name 2";

            Athlete athlete2 = new Athlete(athlete2Name);
            gym.AddAthlete(athlete2);
            names.Add(athlete2.FullName);

            string athlete3Name = "Name 3";

            Athlete athlete3 = new Athlete(athlete3Name);
            gym.AddAthlete(athlete3);
            gym.InjureAthlete(athlete3Name);

            string expected = $"Active athletes at {GymName}: {string.Join(", ", names)}";

            string actual = gym.Report();

            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}
