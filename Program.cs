class Factory
{
    public event Action<Car>? makeTransport;
    public event Func<string, int, Transport>? order;
    public event Predicate<Transport>? isUltraVersion;

    public bool VersionCheck(Transport transport)
    {
        if (transport.Power < 400)
        {
            Console.WriteLine("Is your car ultra: false"); 
            return false;
        }

        Console.WriteLine("Is your car ultra: true");
        return true;
    }

    public Transport? ExecuteOrder(string name, int power)
    {
        return order?.Invoke(name, power);
    }

    public Car FactoryConsume(string name, int power)
    {
        // выбор пользователя тут допустим switch и выбрал сделать машину.
        var car = new Car(name, power);
        Console.WriteLine($"Version power: {power}");

        makeTransport?.Invoke(car);
        return car;
    }

    public void PrintStatus(Transport vehicle)
    {
        Console.WriteLine($"Making and stage your car");
    }

    public void PrintStageImprove(Transport vehicle)
    {
        vehicle.Power += 50;
        Console.WriteLine($"Ultra version activated");
        isUltraVersion?.Invoke(vehicle);
    }
}

class Transport
{
    public string Name { get; }
    public int Power { get; set;  }

    public Transport(string name, int power)
    {
        Name = name;
        Power = power;
    }
}

class Car : Transport
{
    public Guid CID { get; }
    public Car(string name, int power) : base(name, power)
    {
        CID = Guid.NewGuid();
    }
}

class Program
{
    static void Main()
    {
        Factory factory = new Factory();
        factory.order += factory.FactoryConsume;
        factory.makeTransport += factory.PrintStatus;
        factory.makeTransport += factory.PrintStageImprove;
        factory.isUltraVersion += factory.VersionCheck;

        Transport? car = factory.ExecuteOrder("bmw", 400);

        if(car is Car displayCar)
        {
            Console.WriteLine($"car test: | name: {displayCar.Name}, car power: {displayCar.Power}, car CID: {displayCar.CID}");
        }
    }
}