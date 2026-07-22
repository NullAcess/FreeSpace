/*
 
### 9. Реализация интерфейсов в базовых и производных классах

* **Контекст:** Иерархия логирования.
* **Задание:**
1. Создайте интерфейс `ILogger` с методом `void Log(string message)`.
2. Создайте базовый класс `BaseLogger : ILogger`, реализующий метод `Log` как **`virtual`**.
3. Создайте производный класс `FileLogger : BaseLogger` и переопределите метод `Log` через **`override`**.
4. Сохраните объект `FileLogger` в переменную типа `ILogger` и убедитесь, что при вызове `logger.Log()` выполняется переопределенная логика из `FileLogger`.

*/

interface ILogger
{
    void Log(string message);
}

class BaseLogger : ILogger, ICloneable
{
    public string name = "Name: BASE logger";

    public BaseLogger(string name)
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

    public object Clone()
    {
        return MemberwiseClone();
    }
}
class FileLogger : BaseLogger
{
    public FileLogger(string name) : base(name) { }

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
        ILogger logger = new FileLogger("Name_Logger_File");
        logger.Log("empty message");

        if (logger is FileLogger fileLogger)
        {
            fileLogger.Print();

            FileLogger fileLoggerAddition = (FileLogger)fileLogger.Clone();
            Console.WriteLine(fileLoggerAddition.name);
        }
    }
}