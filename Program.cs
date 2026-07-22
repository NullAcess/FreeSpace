class Player : IComparable<Player>
{
    public string Nickname { get; private set; }
    public int Score { get; private set; }
    public int Level { get; private set; }

    public Player(string nickname, int score, int level)
    {
        Nickname = nickname;
        Score = score;
        Level = level;
    }

    public int CompareTo(Player other)
    {
        if (other == null) return 1;
        
        int scoreResult = other.Score.CompareTo(Score);
        if(scoreResult != 0)
        {
            return scoreResult;
        }

        return Nickname.CompareTo(other.Nickname);
    }
}

class Program
{
    static void Main()
    {
        var leaderboard = new List<Player>
            {
                new Player("Shadow", 2500, 50),
                new Player("Alex", 3100, 70),
                new Player("CyberNinja", 2500, 45),
                new Player("Alpha", 3100, 80),
                new Player("Beginner", 1000, 10)
            };

        leaderboard.Sort();

        foreach(Player user in leaderboard)
        {
            Console.WriteLine($"{user.Nickname} | {user.Score} | {user.Level}");
        }
    }
}