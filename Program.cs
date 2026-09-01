using System.Runtime.CompilerServices;

class Program
{
    private static Func<int, int, int> sum = (x, y) => { return x + y; };
    private static Func<int, int, int> multiply = (x, y) => { return x * y; };

    static void Start(Func<int> operation, [CallerMemberName] string callerName = "") // Strategy pattern
    {
        Console.WriteLine($"CALLER [{callerName}]");
        Console.WriteLine($"result: {operation?.Invoke()}");
    }

    static void Main()
    {
        while (true)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1: Start(() => { return sum(5, 4); }); break;
                case ConsoleKey.D2: Start(() => { return multiply(5, 4); }); break;
            }
        }
    }
}