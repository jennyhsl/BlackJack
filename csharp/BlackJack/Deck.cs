using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Deck
    {
        public Queue<Card> Cards;

        private readonly Random _random;
        
        public Deck()
        {
            Cards = new Queue<Card>();
            _random = new();
            
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Face face in Enum.GetValues(typeof(Face)))
                {
                    Cards.Enqueue(new Card() { face = face, Suit = suit });
                }
            }
        }

        public Card DrawCard()
        {
            int randomCard = _random.Next(Cards.Count);
            return Cards.ElementAt(randomCard);
        }
    }
}
