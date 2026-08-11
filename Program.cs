class Program
{
    async static Task Main(string[] args)
    {
        var task = PrintAsync();
        Console.WriteLine();
        Console.WriteLine("Некоторые действия в методе Main");
        await task;

        async Task PrintAsync()
        {
            Console.WriteLine("Начало метода PrintAsync");
            await Task.Delay(3000);
            Console.WriteLine("Hello METANIT.COM");
            Console.WriteLine("Конец метода PrintAsync");
        }
    }
}