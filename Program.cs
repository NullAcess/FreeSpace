using System.Threading.Channels;

interface IDriveable
{
    const int MIN_SPEED = 0;
    const int MAX_SPEED = 100;
    int Speed { get; }

    Action<int>? driveHandler { get; set; }
    Action? errorHandler { get; set; }
    public void Drive()
    {
        if (Speed < MIN_SPEED || Speed > MAX_SPEED) { errorHandler?.Invoke(); }
        else driveHandler?.Invoke(Speed);
    }
}

class Car : IDriveable
{
    public Action<int>? driveHandler { get; set; }
    public Action? errorHandler { get; set; }

    public int Speed { get; private set; }
    public Car(int speed) => Speed = speed;
}


class Program
{
    static void PrintError() => Console.WriteLine("Wrong value to set speed");
    static void PrintSpeed(int speed) => Console.WriteLine($"Your current speed: {speed}");
    static void Main()
    {
        IDriveable vehicle = new Car(55);
        vehicle.driveHandler += PrintSpeed;
        vehicle.errorHandler += PrintError;

        vehicle.Drive();
    }
}