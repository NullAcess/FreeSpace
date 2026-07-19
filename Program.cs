delegate void MakeTransport<in TСar>(TСar car);
delegate TTransport Order<out TTransport>(string name, int power);

class Factory
{
    public event MakeTransport<Car>? makeTransport;
    public event Order<Transport>? order;

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

        Transport? car = factory.ExecuteOrder("bmw", 400);

        if(car is Car displayCar)
        {
            Console.WriteLine($"car test: | name: {displayCar.Name}, car power: {displayCar.Power}, car CID: {displayCar.CID}");
        }
    }
}