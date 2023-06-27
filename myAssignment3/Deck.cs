namespace myAssignment3;

public class Deck
    {
        private static Deck? instance;
        private List<Card> cards;
        private Random random;

        private Deck()
        {
            cards = new List<Card>();
            random = new Random();
        }

        public static Deck Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Deck();
                }
                return instance;
            }
        }

        
        public int CardsRemaining
        {
            get { return cards.Count; }
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public void RemoveCard(Card card)
        {
            cards.Remove(card);
        }

        public void Shuffle()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                int randomIndex = random.Next(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }
            Console.WriteLine("Deck shuffled.");
        }

        public Card? DrawCard()
        {
            if (cards.Count > 0)
            {
                Card drawnCard = cards[0];
                cards.RemoveAt(0);
                return drawnCard;
            }
                        else
            {
                return null;
            }
        }

        public List<Card> DrawCards(int count)
        {
            List<Card> drawnCards = new List<Card>();
            for (int i = 0; i < count; i++)
            {
                Card? card = DrawCard();
                if (card != null)
                {
                    drawnCards.Add(card);
                }
                else
                {
                    break;
                }
            }
            return drawnCards;
        }
    }