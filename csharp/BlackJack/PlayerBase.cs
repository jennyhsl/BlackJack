namespace BlackJack;

public abstract class PlayerBase
{
    public int CurrentTotal;
    public int CardCount;

    protected int softAces;
    protected readonly Deck deck;

    protected PlayerBase(Deck deck)
    {
        this.deck = deck;
    }
}