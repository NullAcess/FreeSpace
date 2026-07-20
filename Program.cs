interface IDataBaseConnect
{
    void DataBaseConnect();
}

interface IDataGet
{
    Guid GetData();
}

interface IDataProcess
{
    void DataProcessDisplay(Guid data);
}

class Data : IDataBaseConnect
{
    public Func<Guid>? getData;
    public Guid GuidData { get; private protected set; }

    public void DataBaseConnect()
    {
        GuidData = getData?.Invoke() ?? Guid.Empty;
    }
}

class DataGet : IDataGet
{
    public event Action<Guid>? displayData;
    public Guid GetData()
    {
        Guid guid = Guid.NewGuid();
        displayData?.Invoke(guid);
        return guid;
    }
}

class DataProcess : IDataProcess
{
    public void DataProcessDisplay(Guid data)
    {
        Console.WriteLine($"Your data: {data}");
    }
}

class Program
{
    static void Main()
    {
        Data data = new Data();
        DataGet dataGet = new DataGet();
        DataProcess dataProcess = new DataProcess();

        data.getData += dataGet.GetData;
        dataGet.displayData += dataProcess.DataProcessDisplay;

        data.DataBaseConnect();
    }
}