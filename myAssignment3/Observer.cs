namespace myAssignment3;


// Observer pattern for game updates
public interface IObserver 
{
    void Update(string message);
}

// Observer pattern for game updates
public class GameObserver : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Game Observer: {message}");
    }
}