namespace myAssignment3{


 // Observer pattern for players
    public class Player : IObserver
    {
        private string name;
        private List<Card> hand;
        private int life;
        private List<IObserver> observers;
        public string Name { get { return name; } }

        public int HandCount
        {
            get { return hand.Count; }
        }

        public Player(string name)
        {
            this.name = name;
            this.hand = new List<Card>();
            this.life = 0;
            this.observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }

        public void Update(string message)
        {
            Console.WriteLine($"{name} received an update: {message}");
        }

        public void SetLife(int value)
        {
            life = value;
        }

                public int GetLife()
        {
            return life;
        }

        public void DrawCard(Deck deck)
        {
            Card? drawnCard = deck.DrawCard();
            if (drawnCard != null)
            {
                hand.Add(drawnCard);
                Console.WriteLine($"{name} drew a card");
            }
            else
            {
                Console.WriteLine("No more cards in the deck.");
            }
        }
        
        public void PlayCard()
        {
            if (hand.Count > 0)
            {
                Console.WriteLine($"{name}'s hand: ");
                for (int i = 0; i < hand.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {hand[i].Name}");
                }
                
                Console.Write("Select a card to play: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int selectedIndex))
                    {
                        selectedIndex--; // Adjust index to match 0-based list
                        if (selectedIndex >= 0 && selectedIndex < hand.Count)
                        {
                            Card selectedCard = hand[selectedIndex];

                            Console.WriteLine($"{name} played {selectedCard.Name}");
                            NotifyObservers($"Played {selectedCard.Name}");

                            hand.RemoveAt(selectedIndex);

                            // Apply the card's effect
                            selectedCard.ApplyEffect(this);
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please enter a valid number.");
                    }
            }
        }


        public void Attack(Player target)
        {
            Console.WriteLine($"{name} is attacking {target.Name}");
            target.Defend();
        }

        public void Defend()
        {
            // Defend logic here
            // Subtract damage from life
            life--;

            // Check if life reaches 0 or below
            if (life <= 0)
            {
                Console.WriteLine($"{name}'s life reached 0 or below. Game over!");
            }
        }


        public void AssignHand(List<Card> hand)
        {
            this.hand = hand;
        }
    }
}