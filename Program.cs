using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;

delegate K Sum<T, K>(T x, T y) where T : INumber<T>;
delegate Auth Auth();

class Authorization
{
    public static Auth AuthWelcome()
    {
        Console.WriteLine("Dear user");
        return AuthBye;
    }

    public static Auth AuthBye()
    {
        Console.WriteLine("Dear user");
        return null;
    }
}

class Operation
{
    public static void DoPrint(Sum<double, bool> sum)
    {
        Console.WriteLine(sum(5,4));
    }

    public static bool SumBoolPrint<T>(T x, T y) where T : INumber<T>
    {
        if (x + y > x) return true;
        return false;
    }

    public static bool GetSubstractBoolPrint<T>(T x, T y) where T : INumber<T>
    {
        if (x - y > x) return true;
        return false;
    }
}

class Program
{
    static Sum<double, bool> OperationChoose(string choice)
    {
        switch (choice)
        {
            case "sum": return Operation.SumBoolPrint;
            case "substract": return Operation.GetSubstractBoolPrint;
            default: return Operation.SumBoolPrint;
        }
    }

    static void Main()
    {
        Sum<double, bool> sum = OperationChoose("substract");
        Operation.DoPrint(sum);
    }
}