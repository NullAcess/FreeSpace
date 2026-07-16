delegate int GameHandler(Game game, int resist);

class Game
{
    private GameHandler gameHandler = delegate
    {
        return 50;
    };
    public int Damage { get; set; }
    public Game(int damage)
    {
        Damage = gameHandler(this, 10);
    }
    public void RegisterHandler(GameHandler gameHandler)
    {
        this.gameHandler = gameHandler;
    }

    public void DoDamage()
    {
        int result = gameHandler?.Invoke(this, 10) ?? -1;
        Console.WriteLine($"Final damage: {result}");
    }
}
class Program
{
    public static int DamageResist(Game game, int resist)
    {
        int result = game.Damage -= resist;
        return result;
    }

    static void Main()
    {
        var game = new Game(45);
        game.RegisterHandler(DamageResist);
        game.DoDamage();
    }
}