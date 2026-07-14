struct RoomDiameter
{
    public int X { get; }
    public int Y { get; }
    public int Z { get; }

    public RoomDiameter(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public void PrintDiametr()
    {
        Console.WriteLine($"x: {X}, y: {Y}, z: {Z}");
    }
}

class Room
{
    public RoomDiameter roomDiameter;
    public string Name { get; private set; }

    public Room(string name, RoomDiameter roomDiameter)
    {
        this.roomDiameter = roomDiameter;
        Name = name;
    }

    public void Print()
    {
        Console.WriteLine($"Name: {Name}");
        roomDiameter.PrintDiametr();
    }
}

class EmptyRoom : Room
{
    private const string _name = "EmptyRoom";

    public EmptyRoom() : base(_name, new RoomDiameter())
    {
        
    }
}

class BasicRoom : Room
{
    private const string _name = "BasicRoom";

    public BasicRoom() : base(_name, new RoomDiameter(5, 5, 5))
    {

    }
}

class Program
{
    static void Main()
    {
        var emptyRoom = new EmptyRoom();
        var basicRoom = new BasicRoom();

        emptyRoom.Print();
        Console.WriteLine();
        basicRoom.Print();
    }
}