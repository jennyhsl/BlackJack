using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            var hand = new List<Card>();

            while (true)
            {
                Console.WriteLine("Stand, Hit");
                string read = Console.ReadLine();
                if (read == "Hit")
                {
                    var card = deck.DrawCard();
                    hand.Add(card);
                    var total = hand.Sum(x => Math.Min((int)x.face, 10));
                    Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, card.face, total);
                    if (total > 21)
                    {
                        Console.WriteLine("You got more than 21 points, you lost.");
                        break;
                    }
                }
                else if (read == "Stand")
                {
                    break;
                }
            }
        }
    }
}
