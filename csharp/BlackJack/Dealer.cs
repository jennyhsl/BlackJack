using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack;

public class Dealer
{
    public List<Card> hand;
    public int handValue;
    public int softAces;
    public Deck deck;

    public Dealer(Deck deck)
    {
        this.deck = deck;
        hand = new List<Card>();
        softAces = 0;
        handValue = 0;
    }

    public void DrawCard()
    {
        var card = deck.DrawCard();
        hand.Add(card);
        if (card.face == Face.A)
        {
            softAces++;
        }

        handValue = Program.GetHandValue(hand, softAces);
    }
    
    public void Play(int playerHandValue)
    {
        while (handValue < 17)
        {
            DrawCard();
            Console.WriteLine("Dealer Draws {0} {1}. Total is {2}", hand.Last().Suit, hand.Last().face, handValue);
        }
        if (handValue > 21)
        {
            Console.WriteLine("Dealer Lost, You win");
        }
        else if (handValue > playerHandValue)
        {
            Console.WriteLine("Dealer wins");
        }
        else if (handValue == playerHandValue)
        {
            Console.WriteLine("It's a tie");
        }
        else
        {
            Console.WriteLine("You win");
        }
    }
}