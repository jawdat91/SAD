namespace myAssignment3;

public class GameManager
    {
        private static GameManager? instance;

        private GameManager()
        {
        }

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public void PlayGame()
        {
            // Create players
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            // Create deck and shuffle cards
            Deck deck = Deck.Instance;
            

          
            for (int i = 0; i < 60; i++)
            {
                // Create a new card and add it to the deck
                Card card = new Card($"Card {i + 1}", "Type");
                deck.AddCard(card);
            }
            deck.Shuffle();

            // Draw initial hands
            List<Card> player1Hand = deck.DrawCards(7);
            List<Card> player2Hand = deck.DrawCards(7);

            // Assign the drawn cards to player hands
            player1.AssignHand(player1Hand);
            player2.AssignHand(player2Hand);

            // Initialize players' life
            player1.SetLife(10);
            player2.SetLife(10);

            // Create and register game observers
            GameObserver gameObserver = new GameObserver();
            player1.RegisterObserver(gameObserver);
            player2.RegisterObserver(gameObserver);

            // Game loop
            bool gameEnd = false;
            while (!gameEnd)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Player 1's turn");
                if (deck.CardsRemaining > 0)
                {
                    player1.DrawCard(deck);
                    if (player1.HandCount > 0)
                    {
                        player1.PlayCard();
                        player1.Attack(player2);
                    }
                    else
                    {
                        Console.WriteLine("Player 1's hand is empty. Cannot play a card.");
                    }
                }
                else
                {
                    Console.WriteLine("No more cards in the deck.");
                }
                Console.WriteLine();

                Console.WriteLine("----------------------------");
                Console.WriteLine("Player 2's turn");
                if (deck.CardsRemaining > 0)
                {
                    player2.DrawCard(deck);
                    if (player2.HandCount > 0)
                    {
                        player2.PlayCard();
                        player2.Attack(player1);
                    }
                    else
                    {
                        Console.WriteLine("Player 2's hand is empty. Cannot play a card.");
                    }
                }
                else
                {
                    Console.WriteLine("No more cards in the deck.");
                }
                Console.WriteLine();

                // Check if the game has ended
                if (player1.GetLife() <= 0 || player2.GetLife() <= 0 || deck.CardsRemaining == 0)
                {
                    gameEnd = true;
                }
            }

        }
    }