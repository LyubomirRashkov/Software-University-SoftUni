namespace RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
	using System.Linq;

	public class Arena : IArena
    {
        private readonly Dictionary<int, BattleCard> cards;

        public Arena()
        {
            this.cards = new Dictionary<int, BattleCard>();
        }

        public int Count => this.cards.Count;

        public bool Contains(BattleCard card) => this.cards.ContainsKey(card.Id);

        public void Add(BattleCard card)
        {
            if (!this.cards.ContainsKey(card.Id))
            {
                this.cards.Add(card.Id, card);
            }
        }

        public void ChangeCardType(int id, CardType type)
        {
            this.ValidateCardExists(id);

            this.cards[id].Type = type;
        }

        public BattleCard GetById(int id)
        {
            this.ValidateCardExists(id);

            return this.cards[id];
        }

        public void RemoveById(int id)
        {
            this.ValidateCardExists(id);

            this.cards.Remove(id);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            var filteredCards = this.cards
                .Where(kvp => kvp.Value.Type == type)
                .Select(kvp => kvp.Value)
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id);

            this.ValidateCollectionIsNotEmpty(filteredCards);

            return filteredCards;
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            var filteredCards = this.GetByCardType(type)
                .Where(c => c.Damage >= lo && c.Damage <= hi);

            this.ValidateCollectionIsNotEmpty(filteredCards);

            return filteredCards;
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            var filteredCards = this.GetByCardType(type)
                .Where(c => c.Damage <= damage);

            this.ValidateCollectionIsNotEmpty(filteredCards);

            return filteredCards;
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            var filteredCards = this.cards
                .Where(kvp => kvp.Value.Name == name)
                .Select(kvp => kvp.Value)
                .OrderByDescending(c => c.Swag)
                .ThenBy(c => c.Id);

            this.ValidateCollectionIsNotEmpty(filteredCards);

            return filteredCards;
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            var filteredCards = this.GetByNameOrderedBySwagDescending(name)
                .Where(c => c.Swag >= lo && c.Swag < hi);

            this.ValidateCollectionIsNotEmpty(filteredCards);

            return filteredCards;
        }

		public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if (n > this.cards.Count)
            {
                throw new InvalidOperationException();
            }

            return this.cards
                .OrderBy(kvp => kvp.Value.Swag)
                .ThenBy(kvp => kvp.Value.Id)
                .Take(n)
                .Select(kvp => kvp.Value);
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
            => this.cards
               .Where(kvp => kvp.Value.Swag >= lo && kvp.Value.Swag <= hi)
               .Select(kvp => kvp.Value)
               .OrderBy(c => c.Swag);

        public IEnumerator<BattleCard> GetEnumerator()
        {
            foreach (var card in this.cards.Values)
            {
                yield return card;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

		private void ValidateCardExists(int id)
		{
            if (!this.cards.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }
		}

		private void ValidateCollectionIsNotEmpty(IEnumerable<BattleCard> collection)
		{
            if (collection.Count() == 0)
            {
                throw new InvalidOperationException();
            }
		}
    }
}