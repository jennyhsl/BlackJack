using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack;

class Dealer
{
    private Deck deck;
    private List<Card> hand;
    private int softAces;
    public int handValue;

    public Dealer(Deck deck)
    {
        this.deck = deck;
        hand = new List<Card>();
        softAces = 0;
        handValue = 0;
    }

    public void Play()
    {
        // Dealer hits until hand value is at least 17
        while (handValue < 17)
        {
            var card = deck.DrawCard();
            hand.Add(card);
            Program.UpdateCardValues(card, ref softAces, ref handValue);
        }

        if (handValue > 21)
        {
            Console.WriteLine("Dealer's hand is over 21, player wins.");
        }
        else
        {
            Console.WriteLine("Dealer's final hand value is {0}", handValue);
        }
    }
    
    public void DrawInitialCards()
    {
        hand.Add(deck.DrawCard());
        hand.Add(deck.DrawCard());
        Program.UpdateCardValues(hand[0], ref softAces, ref handValue);
        Program.UpdateCardValues(hand[1], ref softAces, ref handValue);
    }
}
