interface IJumpable
{
    protected const int JUMP_HEIGHT = 10;
    protected void Jump(int x, int y)
    {
        Console.WriteLine("Hello");
    }
    public delegate void JumpHandler(string message);
}

class Hero : IJumpable
{
    public event IJumpable.JumpHandler? jumpable;

    public void Jump(int x, int y)
    {
        Console.WriteLine($"Your new position: x: {x} y: {y + IJumpable.JUMP_HEIGHT}");
        jumpable?.Invoke("You are jumping!");
    }
}

class Program
{
    static void Print(string message)
    {
        Console.WriteLine($"Jump message: {message}");
    }

    static void Main()
    {
        var Hero = new Hero();
        Hero.jumpable += Print;
        Hero.Jump(15, 2);
    }
}