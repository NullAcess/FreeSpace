public interface IMyCloneable<T>
{
    T Clone();
}

interface ILogger
{
    void Log(string message);
}

class BaseLogger : ILogger, IMyCloneable<BaseLogger>
{
    public string name = "Name: BASE logger";

    public BaseLogger(string name = "B")
    {
        this.name = name;
    }

    public virtual void Log(string message)
    {
        Console.WriteLine(message);
    }

    public virtual void Print()
    {
        Console.WriteLine("Base logger");
    }

    public BaseLogger Clone()
    {
        return (BaseLogger)MemberwiseClone();
    }
}
class FileLogger : BaseLogger
{
    public FileLogger(string name = "S") : base(name) { }

    public override void Log(string message)
    {
        Console.WriteLine(message);
    }
    public override void Print()
    {
        Console.WriteLine("File logger");
    }
}

class Program
{
    static void Main()
    {
        ILogger logger = new BaseLogger();
        logger.Log("empty message");

        BaseLogger fileLoggerAddition;

        if (logger is FileLogger fileLogger)
        {
            fileLogger.Print();
            fileLoggerAddition = fileLogger.Clone();
            Console.WriteLine(fileLoggerAddition.name);
        }
        else if (logger is BaseLogger baseLogger)
        {
            baseLogger.Print();
            fileLoggerAddition = baseLogger.Clone();
            Console.WriteLine(fileLoggerAddition.name);
        }

    }
}