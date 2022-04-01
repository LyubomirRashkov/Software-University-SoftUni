using System;
using System.Collections.Generic;

namespace _03.Cards
{
    public class Card
    {
        private static HashSet<string> validFaces = new HashSet<string>
                                                    { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        private string face;

        public Card(string face, Suit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public string Face
        {
            get => this.face;

            private set
            {
                if (!validFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                this.face = value;
            }
        }

        public Suit Suit { get; private set; }

        public override string ToString()
        {
            char visualSuit = '\0';

            if (this.Suit == Suit.S)
            {
                visualSuit = '\u2660';
            }
            else if (this.Suit == Suit.H)
            {
                visualSuit = '\u2665';
            }
            else if (this.Suit == Suit.D)
            {
                visualSuit = '\u2666';
            }
            else if (this.Suit == Suit.C)
            {
                visualSuit = '\u2663';
            }

            return $"[{this.Face}{visualSuit}]";
        }
    }
}
