using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int DummyHealthWhenDummyIsAlive = 10;
        private const int DummyExperience = 10;
        private const int AttackPoints = 2;

        [Test]
        public void TakeAttack_DecreasesDummyHealthWithAttackPoints()
        {
            Dummy dummy = new Dummy(DummyHealthWhenDummyIsAlive, DummyExperience);

            dummy.TakeAttack(AttackPoints);

            Assert.That(dummy.Health, Is.EqualTo(DummyHealthWhenDummyIsAlive - AttackPoints));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void IsDead_ReturnsTrue_WhenDummyHealthIsEqualToOrLessThanZero(int dummyHealth)
        {
            Dummy dummy = new Dummy(dummyHealth, DummyExperience);

            Assert.That(dummy.IsDead(), Is.True);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void TakeAttack_ThrowsException_WhenDummyIsDead(int dummyHealth)
        {
            Dummy dummy = new Dummy(dummyHealth, DummyExperience);

            Assert.That(() => dummy.TakeAttack(AttackPoints), Throws.InvalidOperationException, "Dummy is dead.");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void GiveExperince_GivesExperienceEqualToDummyExperienceWhenDummyIsDead(int dummyHealth)
        {
            Dummy dummy = new Dummy(dummyHealth, DummyExperience);

            int givenExperience = dummy.GiveExperience();

            Assert.That(givenExperience, Is.EqualTo(DummyExperience));
        }

        [Test]
        public void GiveExperience_ThrowsException_WhenDummyIsNotDead()
        {
            Dummy dummy = new Dummy(DummyHealthWhenDummyIsAlive, DummyExperience);

            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException, "Target is not dead.");
        }
    }
}