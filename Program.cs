interface ILogWriter<in T>
{
    void WriteLog(T log);
}

interface ILogReader<out T>
{
    T ReadLog();
}

public class LogMessage : ILogWriter<LogMessage>
{
    public string Text { get; private set; }
    public LogMessage(string text) => Text = text;

    public void WriteLog(LogMessage logMessage)
    {
        logMessage.Text = Text;
    }
}

public class CriticalErrorLog : LogMessage, ILogReader<CriticalErrorLog>
{
    public string StackTrace { get; private set; }
    public CriticalErrorLog(string text, string stackTrace) : base(text)
    {
        StackTrace = stackTrace;
    }

    public CriticalErrorLog ReadLog()
    {
        return new CriticalErrorLog(Text, StackTrace);
    }
}

class Program
{
    static void Main()
    {
        LogMessage logMessage = new LogMessage("Error 400");
        CriticalErrorLog criticalErrorLog = new CriticalErrorLog("Unknown error", "Stack #1");

        ILogReader<CriticalErrorLog> logReader = criticalErrorLog;
        CriticalErrorLog criticalErrorLogTemp = logReader.ReadLog();
        ILogWriter<LogMessage> logWriter = logMessage; 
        logWriter.WriteLog(criticalErrorLogNew);

        Console.WriteLine($"Log: {criticalErrorLogNew.Text} | {criticalErrorLogNew.StackTrace}");
    }
}