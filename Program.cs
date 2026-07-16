delegate int GameHandler(Game game, int resist);

class Game
{
    private GameHandler gameHandler;
    public int Damage { get; set; }
    public Game(int damage)
    {
        Damage = damage;
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