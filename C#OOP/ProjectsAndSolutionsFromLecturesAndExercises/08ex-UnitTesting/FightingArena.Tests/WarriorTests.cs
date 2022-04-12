namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private const int MinAttackHp = 30;

        [Test]
        [TestCase(null, 10, 100)]
        [TestCase("", 10, 100)]
        [TestCase(" ", 10, 100)]
        [TestCase("Warrior", 0, 100)]
        [TestCase("Warrior", -10, 100)]
        [TestCase("Warrior", 10, -100)]
        public void Ctor_ThrowsException_WhenThereIsAnInvalidParameter(string name, int damage, int hp)
        {
            Assert.That(() => new Warrior(name, damage, hp), Throws.ArgumentException);
        }

        [Test]
        public void Ctor_CreatesAnInstanceWithInitialParameters_WhenParametersAreValid()
        {
            string name = "Warrior";
            int damage = 10;
            int hp = 100;

            Warrior warrior = new Warrior(name, damage, hp);

            Assert.That(warrior.Name, Is.EqualTo(name));
            Assert.That(warrior.Damage, Is.EqualTo(damage));
            Assert.That(warrior.HP, Is.EqualTo(hp));
        }

        [Test]
        [TestCase(MinAttackHp - 1, MinAttackHp + 1)]
        [TestCase(MinAttackHp, MinAttackHp + 1)]
        [TestCase(MinAttackHp + 1, MinAttackHp - 1)]
        [TestCase(MinAttackHp + 1, MinAttackHp)]
        public void Attack_ThrowsException_WhenWarriorHpIsLessThanOrEqualToMinAttackHp(int attackerHp, int defenderHp)
        {
            string attackerName = "Attacker";
            int attackerDamage = 10;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHp);

            string defenderName = "Defender";
            int defenderDamage = 10;

            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHp);

            Assert.That(() => attacker.Attack(defender), Throws.InvalidOperationException);
        }

        [Test]
        public void Attack_ThrowsException_WhenAttackerHpIsLessThanDefenderDamage()
        {
            string attackerName = "Attacker";
            int attackerDamage = 10;
            int attackerHp = 50;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHp);

            string defenderName = "Defender";
            int defenderDamage = 100;
            int defenderHp = 100;

            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHp);

            Assert.That(() => attacker.Attack(defender), Throws.InvalidOperationException,
                                                         "You are trying to attack too strong enemy");
        }

        [Test]
        public void Attack_ReducesAttackerHpWithDefenderDamage_WhenExceptionIsNotThrown()
        {
            string attackerName = "Attacker";
            int attackerDamage = 10;
            int attackerHp = 100;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHp);

            string defenderName = "Defender";
            int defenderDamage = 5;
            int defenderHp = 100;

            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHp);

            attacker.Attack(defender);

            Assert.That(attacker.HP, Is.EqualTo(attackerHp - defender.Damage));
        }

        [Test]
        [TestCase(50)]
        [TestCase(100)]
        public void Attack_ReducesDefenderHpWithAttackerDamage_WhenDefenderHpIsEqualToOrMoreThanAttackerDamage(int defenderHp) 
        {
            string attackerName = "Attacker";
            int attackerDamage = 50;
            int attackerHp = 100;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHp);

            string defenderName = "Defender";
            int defenderDamage = 5;

            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHp);

            attacker.Attack(defender);

            Assert.That(defender.HP, Is.EqualTo(defenderHp - attacker.Damage));
        }

        [Test]
        public void Attack_SetsDefenderHpToZero_WhenDefenderHpIsLessThanAttackerDamage() 
        {
            string attackerName = "Attacker";
            int attackerDamage = 50;
            int attackerHp = 100;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHp);

            string defenderName = "Defender";
            int defenderDamage = 5;
            int defenderHp = 40;

            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHp);

            attacker.Attack(defender);

            Assert.That(defender.HP, Is.EqualTo(0));
        }
    }
}