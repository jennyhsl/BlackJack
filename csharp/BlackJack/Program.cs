using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack;

class Program
{
    static void Main(string[] args)
    {
        var deck = new Deck();
        var hand = new List<Card>();
        var softAces = 0;
        int handValue = 0;

        var dealer = new Dealer(deck);

        while (true)
        {
            Console.WriteLine("Stand, Hit");
            string read = Console.ReadLine();
            if (read == "Hit")
            {
                var card = deck.DrawCard();
                hand.Add(card);
                if (card.face == Face.A)
                {
                    softAces++;
                }

                var total = GetHandValue(hand, softAces);
                Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, card.face, total);
                if (total > 21)
                {
                    Console.WriteLine("You got more than 21 points, you lost.");
                    break;
                }
                if (total == 21)
                {
                    Console.WriteLine("You got exactly 21 points, you win!");
                    break;
                }
            }
            else if (read == "Stand")
            {
                break;
            }
        }
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
