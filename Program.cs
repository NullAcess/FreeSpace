delegate void GenericDelegate<T>(T value);

class Program
{
    static void OrdinaryMethod(double value)
    {
        Console.WriteLine(value);
    }
    static void GenericMethod<T>(T value)
    {
        Console.WriteLine(value);
    }
    static void Main()
    {
        GenericDelegate<double> genericDelegate = OrdinaryMethod;
        genericDelegate += GenericMethod;

        genericDelegate(5.6136);
        // Console.WriteLine(genericDelegate(5.6136)); to works it you should set return type in your delegate ( Bad: delegate void GenericDelegate<T>(T value); )
        //                                                                                                     ( Good delegate T GenericDelegate<T>(T value);    )
    }
}