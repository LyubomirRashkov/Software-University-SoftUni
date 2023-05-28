using System;
using System.Collections.Generic;
using System.Linq;

public class Board : IBoard
{
    private readonly Dictionary<string, Card> cardsByName = new Dictionary<string, Card>();

    public void Draw(Card card)
    {
        if (this.cardsByName.ContainsKey(card.Name))
        {
            throw new ArgumentException();
        }

        this.cardsByName.Add(card.Name, card);
    }

    public bool Contains(string name) => this.cardsByName.ContainsKey(name);

    public int Count() => this.cardsByName.Values.Count;

    public void Play(string attackerCardName, string attackedCardName)
    {
        if (!this.cardsByName.ContainsKey(attackerCardName)
            || !this.cardsByName.ContainsKey(attackedCardName)
            || this.cardsByName[attackerCardName].Level != this.cardsByName[attackedCardName].Level)
        {
            throw new ArgumentException();
        }

        if (this.cardsByName[attackedCardName].Health <= 0)
        {
            return;
        }

        this.cardsByName[attackedCardName].Health -= this.cardsByName[attackerCardName].Damage;

        if (this.cardsByName[attackedCardName].Health <= 0)
        {
            this.cardsByName[attackerCardName].Score += this.cardsByName[attackedCardName].Level;
        }
    }

    public void Remove(string name)
    {
        if (!this.cardsByName.ContainsKey(name))
        {
            throw new ArgumentException();
        }

        this.cardsByName.Remove(name);
    }

    public void RemoveDeath()
    {
        List<Card> deathCards = this.cardsByName.Values.Where(c => c.Health <= 0).ToList();

        foreach (var card in deathCards)
        {
            this.cardsByName.Remove(card.Name);
        }
    }

    public IEnumerable<Card> GetBestInRange(int start, int end)
        => this.cardsByName.Values
            .Where(c => c.Score >= start && c.Score <= end)
            .OrderByDescending(c => c.Level);

    public IEnumerable<Card> ListCardsByPrefix(string prefix)
        => this.cardsByName.Values
            .Where(c => c.Name.StartsWith(prefix))
            .OrderBy(c => string.Join("", c.Name.Reverse()))
            .ThenBy(c => c.Level);

    public IEnumerable<Card> SearchByLevel(int level)
        => this.cardsByName.Values
            .Where(c => c.Level == level)
            .OrderByDescending(c => c.Score);

    public void Heal(int health)
    {
        this.cardsByName.Values
            .OrderBy(c => c.Health)
            .FirstOrDefault()
            .Health += health;
    }
}