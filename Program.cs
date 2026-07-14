using System.Diagnostics;

class PersonClass
{
    public int Id { get; internal set; }
    public string Name { get; internal set; }
    public PersonClass(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

struct PersonStruct
{
    public int Id { get; internal set; }
    public string Name { get; internal set; }
    public PersonStruct(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

class Program
{
    //static void StructProp<T>(T structStack) where T : PersonStruct ( error )
    //{
    //    structStack.Id ( error )
    //> where T принимает только классы или интферйсы ( error ) : (

    static void StructProp(ref PersonStruct structStack)
    {
        Console.WriteLine("Struct");
        structStack.Id = 1;
        structStack.Name = "StructProp";
    }

    static void ClassProp<T>(T classRef) where T: PersonClass
    {
        Console.WriteLine("CLASS");
        classRef.Id = 2;
        classRef.Name = "ClassProp";
    }

    static void StructTest()
    {
        Console.WriteLine("STRUCT");
        PersonStruct personStruct = new PersonStruct();
        Console.WriteLine(personStruct.Id);
        Console.WriteLine(personStruct.Name);
    }

    static void ClassTest()
    {
        Console.WriteLine("CLASS");
        PersonClass person = new PersonClass(1, "Andrew"); // 0 and nothing : (
        Console.WriteLine(person.Id);
        Console.WriteLine(person.Name);
    }
    static void Main()
    {
        Stopwatch watchTest = Stopwatch.StartNew();
        StructTest();
        watchTest.Stop();
        Console.WriteLine($"Время выполнения: {watchTest.ElapsedMilliseconds} мс");
        Console.WriteLine($"Точное время (такты): {watchTest.ElapsedTicks}");

        Stopwatch watch = Stopwatch.StartNew();
        StructTest();
        watch.Stop();
        Console.WriteLine($"Время выполнения: {watch.ElapsedMilliseconds} мс");
        Console.WriteLine($"Точное время (такты): {watch.ElapsedTicks}");

        Thread.Sleep(500);

        Stopwatch watch2 = Stopwatch.StartNew();
        ClassTest();
        watch2.Stop();
        Console.WriteLine($"Время выполнения: {watch2.ElapsedMilliseconds} мс");
        Console.WriteLine($"Точное время (такты): {watch2.ElapsedTicks}");

        PersonStruct personStruct = new PersonStruct(); // default values
        PersonClass person = new PersonClass(1, "Andrew"); // 0 and nothing : (

        Stopwatch watch3 = Stopwatch.StartNew();
        ClassProp(person);
        watch3.Stop();
        Console.WriteLine($"Время выполнения: {watch3.ElapsedMilliseconds} мс");
        Console.WriteLine($"Точное время (такты): {watch3.ElapsedTicks}");

        Stopwatch watch4 = Stopwatch.StartNew();
        StructProp(ref personStruct);
        watch4.Stop();
        Console.WriteLine($"Время выполнения: {watch4.ElapsedMilliseconds} мс");
        Console.WriteLine($"Точное время (такты): {watch4.ElapsedTicks}");
    }
}