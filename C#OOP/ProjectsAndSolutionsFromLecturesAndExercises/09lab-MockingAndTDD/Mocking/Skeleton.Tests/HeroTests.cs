using Moq;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void Attack_GivesExperienceAfterAttack_IfTargetDies() 
        {
            const int ExperiencePoints = 20;

            Mock<ITarget> fakeTarget = new Mock<ITarget>();

            fakeTarget.Setup(fT => fT.IsDead()).Returns(true);
            fakeTarget.Setup(fT => fT.GiveExperience()).Returns(ExperiencePoints);

            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

            Hero hero = new Hero("Hero", fakeWeapon.Object);

            hero.Attack(fakeTarget.Object);

            Assert.That(hero.Experience, Is.EqualTo(ExperiencePoints));
        }
    }
}
