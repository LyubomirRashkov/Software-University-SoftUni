using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Cards
{
    public class StartUp
    {
        static void Main()
        {
            string[] inputCards = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<Card> cards = new List<Card>();

            foreach (string inputCard in inputCards)
            {
                string[] currentCard = inputCard
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                string face = currentCard[0];
                string currentSuit = currentCard[1];

                try
                {
                    Card card = CreateCard(face, currentSuit);
                    cards.Add(card);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(String.Join(' ', cards));
        }

        private static Card CreateCard(string inputFace, string inputSuit)
        {
            Card card = null;

            bool isSuitValid = Enum.TryParse(inputSuit, out Suit suit);

            if (!isSuitValid)
            {
                throw new ArgumentException("Invalid card!");
            }

            card = new Card(inputFace, suit);

            return card;
        }
    }
}
