using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private List<Item> pool;

        public WarController()
		{
			this.party = new List<Character>();
			this.pool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string characterName = args[1];

            if (characterType != nameof(Priest) && characterType != nameof(Warrior))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

			Character character = this.CreataCharacter(characterType, characterName);

			this.party.Add(character);

			return String.Format(SuccessMessages.JoinParty, characterName);
		}

        public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

            if (itemName != nameof(FirePotion) && itemName != nameof(HealthPotion))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

			Item item = this.CreateItem(itemName);

			this.pool.Add(item);

			return String.Format(SuccessMessages.AddItemToPool, itemName);
		}

        public string PickUpItem(string[] args)
		{
			string characterName = args[0];

			Character character = this.party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (!this.pool.Any())
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

			Item item = this.pool[this.pool.Count - 1];

			character.Bag.AddItem(item);
			this.pool.RemoveAt(this.pool.Count - 1);

			return String.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = this.party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

			Item item = character.Bag.GetItem(itemName);

			character.UseItem(item);

			return String.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

            foreach (Character character in this.party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
				sb.AppendLine(character.ToString());
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = this.party.FirstOrDefault(c => c.Name == attackerName);

            if (attacker == null)
            {
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

			Character receiver = this.party.FirstOrDefault(c => c.Name == receiverName);

            if (receiver == null)
            {
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}

            if (attacker.GetType().Name != nameof(Warrior))
            {
				throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attackerName));
            }
            else
            {
				Warrior realAttacker = attacker as Warrior;

				realAttacker.Attack(receiver);
            }

			StringBuilder sb = new StringBuilder();

			sb.AppendLine(String.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
				sb.AppendLine(String.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			Character healer = this.party.FirstOrDefault(c => c.Name == healerName);

            if (healer == null)
            {
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

			Character receiver = this.party.FirstOrDefault(c => c.Name == healingReceiverName);

            if (receiver == null)
            {
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
			}

            if (healer.GetType().Name != nameof(Priest))
            {
				throw new ArgumentException(String.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
            else
            {
				Priest realHealer = healer as Priest;

				realHealer.Heal(receiver);
            }

			return String.Format(SuccessMessages.HealCharacter, healerName, healingReceiverName, healer.AbilityPoints, healingReceiverName, receiver.Health);
		}

        private Character CreataCharacter(string characterType, string name)
        {
			Character character = null;

            if (characterType == nameof(Priest))
            {
				character = new Priest(name);
            }
            else
            {
				character = new Warrior(name);
            }

			return character;
        }

        private Item CreateItem(string name)
        {
			Item item = null;

            if (name == nameof(FirePotion))
            {
				item = new FirePotion();
            }
            else
            {
				item = new HealthPotion();
            }

			return item;
        }
	}
}
