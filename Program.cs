class Company<T>
{
    public T Ceo { get; private set; }
    public Company(T ceo)
    {
        Ceo = ceo;
    }

    public void Print() { Console.WriteLine($"ceo: {Ceo}"); }
}

class Person<T, N>
{
    public static T? globalHWID;
    public T Id { get; private set; }
    public N Name { get; private set; }
    public Person(T id, N name)
    {
        Id = id;
        Name = name;
    }

    public void Print() { Console.WriteLine($"id: {Id}, name: {Name}"); }
    public static void Print(T value1, T value2)
    {
        T temp = value1;
        value1 = value2;
        value2 = temp;

        Console.WriteLine($"value 1: {value1}");
        Console.WriteLine($"value 2: {value2}");
    }
}

class Program
{
    static void ViewType<T>(T value)
    {
        Console.WriteLine(value?.GetType());
    }

    static void Main()
    {
        var Andrey = new Person<string, string>("316-microsoft-513", "Andrey");
        Person<string, string>.globalHWID = "HWID-6136MMW";
        Person<int, string>.globalHWID = 63197060;
        var Company = new Company<Person<string, string>>(Andrey);

        Company.Ceo.Print();
        Company.Print();

        Console.WriteLine();

        Console.WriteLine(Person<string, int>.globalHWID ?? "null enter");
        Console.WriteLine(Person<int, string>.globalHWID);

        Console.WriteLine();

        Person<string, string>.Print("3", "5");
        Person<int, string>.Print(1, 66);
        Person<string, int>.Print("TEST", "TEST2");

        Console.WriteLine();

        ViewType(Person<string, string>.globalHWID);
        ViewType(Person<int, string>.globalHWID);
        ViewType(Person<string, int>.globalHWID ?? "System.String :( ");
    }
}