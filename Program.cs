using System.Threading.Channels;

interface IDriveable
{
    const int MIN_SPEED = 0;
    const int MAX_SPEED = 100;
    protected void Drive();
}

class Car : IDriveable
{
    public event Action<int> driveHandler;
    public event Action errorHandler;
    public int Speed { get; private set; }
    public Car(int speed) => Speed = speed;

    public void Drive()
    {
        if (Speed < IDriveable.MIN_SPEED || Speed > IDriveable.MAX_SPEED) { errorHandler.Invoke(); }
        else driveHandler.Invoke(Speed);
    }
 }


class Program
{
    static void PrintError() => Console.WriteLine("Wrong value to set speed");
    static void PrintSpeed(int speed) => Console.WriteLine($"Your current speed: {speed}");
    static void Main()
    {
        var vehicle = new Car(17);
        vehicle.driveHandler += PrintSpeed;
        vehicle.errorHandler += PrintError;

        vehicle.Drive();
    }
}