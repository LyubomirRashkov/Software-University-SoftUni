namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Ctor_InitializesWarriorsWithAnEmptyCollection()
        {
            Assert.That(this.arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void Count_ShouldBeZero_WhenAnArenaIsEmpty()
        {
            Assert.That(this.arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void Enroll_AddsWarriorToTheArenaWarriors()
        {
            Warrior warrior = new Warrior("Warrior", 10, 100);

            this.arena.Enroll(warrior);

            CollectionAssert.Contains(this.arena.Warriors, warrior);
        }

        [Test]
        public void Enroll_ThrowsException_WhenThereIsAWarriorWithTheSameNameInTheArena()
        {
            string warriorName = "Warrior";

            Warrior warrior = new Warrior(warriorName, 10, 100);

            this.arena.Enroll(warrior);

            Warrior warrior2 = new Warrior(warriorName, 20, 200);

            Assert.That(() => this.arena.Enroll(warrior2), Throws.InvalidOperationException,
                                                           "Warrior is already enrolled for the fights!");
        }

        [Test]
        [TestCase("Attacker", "Attacker", "Defender")]
        [TestCase("Defender", "Attacker", "Defender")]
        [TestCase("Warrior", "Attacker", "Defender")]
        public void Fight_ThrowsException_WhenWarriorNamesAreNotValid
                                            (string warriorName, string attackerName, string defenderName) 
        {
            int warriorDamage = 10;
            int warriorHp = 100;

            Warrior warrior = new Warrior(warriorName, warriorDamage, warriorHp);

            this.arena.Enroll(warrior);

            Assert.That(() => this.arena.Fight(attackerName, defenderName), Throws.InvalidOperationException);
        }

        [Test]
        public void Fight_BothFightersLoseHp()
        {
            string attackerName = "Attacker";
            int attackerDamage = 20;
            int attackerHp = 100;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHp);

            this.arena.Enroll(attacker);

            string defenderName = "Defender";
            int defenderDamage = 10;
            int defenderHp = 100;

            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHp);

            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            Assert.That(attacker.HP, Is.EqualTo(attackerHp - defender.Damage));
            Assert.That(defender.HP, Is.EqualTo(defenderHp - attacker.Damage));
        }
    }
}
