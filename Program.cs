interface ICommand
{
    public void Execute();
}

class Person
{
    public void Print()
    {
        Console.WriteLine("Hello world");
    }
}

class PrintCommand : ICommand
{
    private readonly Person _person;
    public PrintCommand(Person person)
    {
        _person = person;
    }

    public void Execute()
    {
        _person.Print();
    }
}

class View
{
    ICommand _command;

    public View(ICommand command)
    {
        _command = command;
    }

    public void Start()
    {
        _command.Execute();
    }
}

class Program
{
    static void Main()
    {
        Person person = new();
        ICommand printCommand = new PrintCommand(person);
        View view = new(printCommand);

        view.Start();
    }
}