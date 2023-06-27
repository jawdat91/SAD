using System;
using System.Collections.Generic;

namespace myAssignment3
{
    // Singleton pattern for game manager
    

    public abstract class CardComponent
    {
        public string Name { get; }
        public string Type { get; }

        public CardComponent(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public abstract void ApplyEffect(Player player);
        public abstract void Play();
    }

    public class Card : CardComponent
    {
        public Card(string name, string type) : base(name, type)
        {
        }

        public override void ApplyEffect(Player player)
        {
            // Apply card effect to the player
        }

        public override void Play()
        {
            // Play card logic
        }
    }
    
}

           






















































