class EmptyClass
{

}

class Person<T> where T : class
{
    public T Id;
    public Person(T id) => Id = id;
}
class AdvancedPerson<T, P> : Person<T> where T : class
{
    public P Name { get; private set; }
    public AdvancedPerson(T id, P name) : base(id) => Name = name;
}

class AdvancedPerson2 : Person<string>
{
    public Guid Code { get; private set; }
    public AdvancedPerson2(Guid code, string id) : base(id) => Code = code;
}


class Message
{
    public string Text { get; private set; }
    public Message(string text) => Text = text;
}

class EmailMessage : Message
{
    public EmailMessage(string text) : base(text) { }
}
class SmsMessage : Message
{
    public SmsMessage(string text) : base(text) { }
}

class DataManager<T, P>
    where T : Message
    where P : Person<string>
{
    private string _hello = "Hello World!";

    public DataManager(string hello)
    {
        _hello = hello;
    }

    public static void SendMessage(P sender, T message)
    {
        Console.WriteLine($"Sender: {sender.Id}");
        Console.WriteLine($"Message: {message.Text}");
    }
}

//class BrowseDataMangaer<T, P> : DataManager<T, P>
//{
//    public BrowseDataMangaer(string helloWorldText) : base(helloWorldText) { }
//}

class EmptyDataManger<T> where T : new()
{
    public T? emptyObject { get; private set; }
    public static void ViewEmptyObjects(T element)
    {
        Console.WriteLine($"Class name: '{element?.GetType()}' is empty");
    }
}

class Program
{
    static void Main()
    {
        Person<string> person = new Person<string>("Andrew");
        Message message = new Message("ordinary message");
        EmailMessage emailMessage = new EmailMessage("mail message");
        SmsMessage smsMessage = new SmsMessage("SmsMessage");

        DataManager<Message, Person<string>>.SendMessage(person, message);
        Console.WriteLine();
        DataManager<EmailMessage, Person<string>>.SendMessage(person, emailMessage);
        Console.WriteLine();
        DataManager<Message, Person<string>>.SendMessage(person, smsMessage);

        Console.WriteLine();

        EmptyClass empty = new EmptyClass();
        EmptyDataManger<EmptyClass>.ViewEmptyObjects(empty);
        //> EmptyDataManger<Message>.ViewEmptyObjects(message); ctor is not empty in Message class

        Person<string> person1 = new Person<string>("115-abc");
        Person<string> personToAdvenced = new AdvancedPerson<string, int>("2424", 737373);
        AdvancedPerson<string, int> personToAdvenced1 = (AdvancedPerson<string, int>)personToAdvenced;

        Console.WriteLine(person1.Id);
        Console.WriteLine(personToAdvenced.Id);
        Console.WriteLine(personToAdvenced1.Id);
        Console.WriteLine(personToAdvenced1.Name);

        AdvancedPerson2 advPerson = new AdvancedPerson2(Guid.NewGuid(), "777");
        Person<string> person2 = new AdvancedPerson2(Guid.NewGuid(), "5555");
        Console.WriteLine(advPerson.Id);

        //> person.Id = 36326; | error convert int to string
    }
}