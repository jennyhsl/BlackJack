using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack;

class Dealer
{
    private Deck _deck;
    private List<Card> _hand;
    private int _softAces;
    public int _handValue;

    public Dealer(Deck deck)
    {
        _deck = deck;
        _hand = new List<Card>();
        _softAces = 0;
        _handValue = 0;
    }

    public void Play()
    {
        // Dealer hits until hand value is at least 17
        while (_handValue < 17)
        {
            var card = _deck.DrawCard();
            _hand.Add(card);
            Program.UpdateCardValues(card, ref _softAces, ref _handValue);
        }

        if (_handValue > 21)
        {
            Console.WriteLine("Dealer's hand is over 21, player wins.");
        }
        else
        {
            Console.WriteLine("Dealer's final hand value is {0}", _handValue);
        }
    }
    
    public void DrawInitialCards()
    {
        _hand.Add(_deck.DrawCard());
        _hand.Add(_deck.DrawCard());
        Program.UpdateCardValues(_hand[0], ref _softAces, ref _handValue);
        Program.UpdateCardValues(_hand[1], ref _softAces, ref _handValue);
    }

    public static int GetHandValue(List<Card> hand, int softAces)
    {
        var total = hand.Sum(x => Math.Min((int)x.face, 10)) + (softAces == 1 ? 10 : 0);
        if (total > 21 && softAces > 0)
        {
            total -= 10;
            softAces--;
        }
        return total;
    }
}
