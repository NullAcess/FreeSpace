class Person
{
    public string Name { get; private set; } = "Unknown";
    public Person(string name) { Name = name; }
}

class Employee : Person
{
    public string Company { get; private set; } = "Unknown";
    public Employee(string name, string company) : base(name)
    {  
        Company = company; 
    }
}

class Program
{
    public static void Main()
    {
        Person President1 = new Employee("Mister1", "Google");
        var President2 = new Person("Mister2");
        var Andrew = new Employee("Andrew", "Microsoft");

        Console.WriteLine($"{President2.Name}\n");
        Console.WriteLine($"{Andrew.Name}");
        Console.WriteLine($"{Andrew.Company}");


        Console.WriteLine(President1.Name);
        Employee trueEmployee = (Employee)President1;
        Console.WriteLine(trueEmployee.Company);

        Console.WriteLine();

        try
        {
            Employee fakeEmployee = (Employee)President2;
            Console.WriteLine(fakeEmployee.Name);
            Console.WriteLine(fakeEmployee.Company); // error 
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("null data");
        }
        finally
        {
            Console.WriteLine("You will see it anyway");
        }

        Person fakeBoss = Andrew;
        Console.WriteLine(fakeBoss.Name);
    }
}