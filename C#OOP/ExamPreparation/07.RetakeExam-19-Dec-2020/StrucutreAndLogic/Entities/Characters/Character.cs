using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private const double MinHealth = 0;
		private const double MinArmor = 0;
		private const bool DefaultIsAlive = true;

		private string name;
		private double baseHealth;
		private double health;
		private double baseArmor;
		private double armor;
		private double abilityPoints;
		private Bag bag;
		private bool isAlive;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
			this.Name = name;
			this.BaseHealth = health;
			this.Health = health;
			this.BaseArmor = armor;
			this.armor = armor;
			this.AbilityPoints = abilityPoints;
			this.Bag = bag;
			this.IsAlive = DefaultIsAlive;
        }

		public string Name
		{
			get => this.name;
			private set
			{
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

				this.name = value;
			}
		}

        public double BaseHealth
		{
			get => this.baseHealth;
			private set 
			{
				this.baseHealth = value;
			}
		}

        public double Health 
		{
			get => this.health;
			set
			{
                if (value > this.BaseHealth)
                {
					value = this.BaseHealth;
                }

                if (value <= MinHealth)
                {
					this.IsAlive = false;

					value = MinHealth;
                }

				this.health = value;
			}
		}

        public double BaseArmor
		{
			get => this.baseArmor;
			private set
			{
				this.baseArmor = value;
			}
		}

        public double Armor 
		{
			get => this.armor;
			private set
			{
                if (value < MinArmor)
                {
					value = MinArmor;
                }

				this.armor = value;
			}
		}

        public double AbilityPoints 
		{
			get => this.abilityPoints;
			private set
			{
				this.abilityPoints = value;
			}
		}

        public Bag Bag 
		{
			get => this.bag;
			private set
			{
				this.bag = value;
			}
		}

        public bool IsAlive
		{
			get => this.isAlive;
			private set
			{
				this.isAlive = value;
			}
		}

		public void TakeDamage(double hitPoints)
		{
			this.EnsureAlive();

			double leftHitPoints = hitPoints - this.Armor;

			this.Armor -= hitPoints;

            if (leftHitPoints > 0)
            {
				this.Health -= leftHitPoints;
            }
		}

		public void UseItem(Item item)
		{
			item.AffectCharacter(this);
		}

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public override string ToString()
        {
            if (IsAlive)
            {
				return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: Alive";
			}
            else
            {
				return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: Dead";
			}
        }
    }
}