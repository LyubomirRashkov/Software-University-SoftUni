using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int DefaultWeight = 5;
        private const double AdditionalHealth = 20;

        public HealthPotion() 
            : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += AdditionalHealth;
        }
    }
}
