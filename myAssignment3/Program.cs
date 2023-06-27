
using System;

namespace myAssignment3
{
    
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = GameManager.Instance;
            gameManager.PlayGame();

            Console.ReadLine();
        }
    }
}