class Program
{
    static void Main()
    {
        var obj = new object();
        int x = 0;

        for (int i = 0; i < 5; i++)
        {
            Thread myThread = new(Print);
            myThread.Name = $"Thread {i}";
            myThread.Start();
        }

        void Print()
        {
            lock (obj)
            {
                x = 1;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                    x++;
                    Thread.Sleep(100);
                }
            }
        }
    }
}