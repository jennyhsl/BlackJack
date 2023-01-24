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
        var playerHand = new List<Card>();
        var playerSoftAces = 0;
        int playerHandValue = 0;

        var dealer = new Dealer(deck);
        dealer.DrawInitialCards();

        while (true)
        {
            Console.WriteLine("Stand, Hit");
            string read = Console.ReadLine();
            if (read == "Hit")
            {
                var card = deck.DrawCard();
                playerHand.Add(card);
                UpdateCardValues(card, ref playerSoftAces, ref playerHandValue);
                Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, card.face, playerHandValue);
                if (playerHandValue > 21)
                {
                    DetermineWinner(playerHandValue, dealer);
                    break;
                }
                if (playerHandValue == 21)
                {
                    DetermineWinner(playerHandValue, dealer);
                    break;
                }
            }
            else if (read == "Stand")
            {
                dealer.Play();
                DetermineWinner(playerHandValue, dealer);
                break;
            }
        }
    }

    public static void UpdateCardValues(Card card, ref int softAces, ref int total)
    {
        // Update card value count according to the BlackJack rules.
        switch (card.face) {
            case Face.A:
                softAces++;
                total += 11;
                break;
            case Face.J:
            case Face.Q:
            case Face.K:
                total += 10;
                break;
            default:
                total += (int)card.face;
                break;
        }

        // Check if the player busts 21 with an ace counting as 11. If so, downgrade the ace.
        while ((total > 21) && (softAces > 0)) {
            softAces--;
            total -= 10;
        }
    }

    private static void DetermineWinner(int playerHandValue, Dealer dealer)
    {
        if (playerHandValue > 21)
        {
            Console.WriteLine("Player's hand is over 21, dealer wins.");
        }
        else if (dealer._handValue > 21)
        {
            Console.WriteLine("Dealer's hand is over 21, player wins.");
        }
        else if (playerHandValue > dealer._handValue)
        {
            Console.WriteLine("Player wins with a hand value of {0}", playerHandValue);
        }
        else if (playerHandValue < dealer._handValue)
        {
            Console.WriteLine("Dealer wins with a hand value of {0}", dealer._handValue);
        }
        else
        {
            Console.WriteLine("It's a draw!");
        }
    }

}
