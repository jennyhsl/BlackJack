namespace BlackJack
{
    public class Card
    {
        public Suit suit;
        public Face face; //face

        public Suit Suit
        {
            get
            {
                return this.suit;
            }
            set
            {
                this.suit = suit;
            }
        }

        public Face Face
        {
            get
            {
                return this.face;
            }

            set
            {
                this.face = value;
            }
        }
    }
}
