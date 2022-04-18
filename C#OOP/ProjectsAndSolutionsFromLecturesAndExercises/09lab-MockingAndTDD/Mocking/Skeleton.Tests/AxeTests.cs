using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int AxeAttack = 2;

        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            int dummyHealth = 10;
            int dummyExperience = 10;

            this.dummy = new Dummy(dummyHealth, dummyExperience);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void Attack_ThrowsException_WhenAxeDurabilityIsEqualToOrLessThanZero(int durabilityPoints)
        {
            Axe axe = new Axe(AxeAttack, durabilityPoints);

            Assert.That(() => axe.Attack(this.dummy), Throws.InvalidOperationException, "Axe is broken.");
        }

        [Test]
        public void Attack_AxeLosesOneDurabilityPointAfterSuccessfullAttack()
        {
            int axeDurabilityPoints = 10;

            Axe axe = new Axe(AxeAttack, axeDurabilityPoints);

            axe.Attack(this.dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(axeDurabilityPoints - 1));
        }
    }
}