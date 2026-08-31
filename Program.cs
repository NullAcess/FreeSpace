using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

class Player
{
    public string UserName { get; } = "Unknown";
    public int Id { get; }

    [JsonConstructor]
    public Player(string userName, int id)
    {
        UserName = userName;
        Id = id;
    }
}

class Program
{
    private const string FilePath = @"C:\Users\ll1on\Desktop";

    private static readonly string CombinePath = Path.Combine(FilePath, "user.json");
    private static readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    private static List<Player> _players = new();
    private static FileInfo fileInfo = new(CombinePath);

    static bool CompareNodes(Player player, Player nodePlayer)
    {
        if (player.UserName == nodePlayer.UserName && player.Id == nodePlayer.Id)
        {
            UserNotification("Data is already exist");
            return false;
        }

        return true;
    }

    static List<Player> LoadJsonData()
    {
        using (FileStream fs = new FileStream(CombinePath, FileMode.Open, FileAccess.Read))
        {
            List<Player> players = JsonSerializer.Deserialize<List<Player>>(fs, jsonSerializerOptions);
            return players;
        }
    }

    static async Task<bool> CheckSave(Player player)
    {
        {
            using (FileStream fs = new FileStream(CombinePath, FileMode.Open, FileAccess.Read))
            {
                List<Player> nodePlayer = await JsonSerializer.DeserializeAsync<List<Player>>(fs, jsonSerializerOptions);

                for (int i = 0; i < nodePlayer.Count; i++)
                {
                    if (!CompareNodes(player, nodePlayer[i]))
                    {
                        UserNotification("Check save: FALSE");
                        return false;
                    }
                }

                UserNotification("Check save: true");
                return true;
            }
        }
    }

    static async Task<bool> SaveToJson(Player player)
    {
        {
            if (!await CheckSave(player))
                return false;

            else
            {
                _players = LoadJsonData();
                _players.Add(player);

                using (FileStream fs = new FileStream(CombinePath, FileMode.Create, FileAccess.Write))
                {
                    await JsonSerializer.SerializeAsync(fs, _players, jsonSerializerOptions);
                    return true;
                }
            }
        }
    }

    static async Task InitializeDefaultFile()
    {
        if (!File.Exists(CombinePath) || fileInfo.Length <= 0)
        {
            var defaultPlayer = new Player("Unknown", -1);

            _players.Add(defaultPlayer);
            using (FileStream fs = new FileStream(CombinePath, FileMode.Create, FileAccess.Write))
            {
                await JsonSerializer.SerializeAsync(fs, _players, jsonSerializerOptions);
                return;
            }
        }
    }

    static async Task Main()
    {
        await InitializeDefaultFile();
        _players = LoadJsonData();

        string userName;
        int id;

        while (true)
        {
            Console.Clear();
            Console.Write("Write username: ");
            userName = Console.ReadLine() ?? String.Empty;
            Console.Write("Write id: ");
            int.TryParse(Console.ReadLine() ?? String.Empty, out id);

            var player = new Player(userName, id);

            Console.WriteLine("1. Save character");
            Console.WriteLine("2. Save check");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1: await SaveToJson(player); continue;
                case ConsoleKey.D2: await CheckSave(player); continue;
                case ConsoleKey.D3: DisplayListOfPlayers(); continue;
                case ConsoleKey.Backspace:; return;
            }
        }
    }

    static void DisplayListOfPlayers()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("===============================================================");

        for (int i = 0; i < _players.Count; i++)
        {
            Console.WriteLine($"Name: {_players[i].UserName} | Id: {_players[i].Id}");
        }

        Console.WriteLine("===============================================================");
        Console.ResetColor();
        Console.ReadKey(true);
        return;
    }

    static void UserNotification(string message)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Thread.Sleep(1000);
        Console.ResetColor();
        Console.Clear();
    }
}