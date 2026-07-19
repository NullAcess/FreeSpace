delegate void MakeTransport(Car car);
delegate Transport Order();

class Program
{
    static void Main()
    {
        Factory factory = new Factory();
        factory.makeTransport += factory.CarStage;

        Car car = factory.CarFactory("bmw", 400);
        Console.WriteLine($"car test: | name: {car.Name}, car power: {car.Power}");
    }
}

class Factory
{
    public event MakeTransport? makeTransport;
    public event Order? order;

    public Car CarFactory(string name, int power)
    {
        Console.WriteLine($"Standart version power: {power}");
        var fabricCar = new Car(name, power);
        makeTransport?.Invoke(fabricCar);
        return fabricCar;
    }

    public void CarStage(Transport transport)
    {
        transport.Power += 50;
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