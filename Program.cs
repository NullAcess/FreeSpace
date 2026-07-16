using static Company;

static class Methods
{
    public delegate void GenericDelegate<T>(T value);

    public static void OrdinaryMethod(double value)
    {
        Console.WriteLine(value);
    }
    public static void GenericMethod<T>(T value)
    {
        Console.WriteLine(value);
    }
}

static class Company
{
    public delegate Test Test();
    public delegate string CompanyDelegate();


    private static Test test = TestMethod();
    public static Test TestMethod()
    {
        test = GetOperation();
        return test;
    }

    public static Test GetOperation()
    {
        return test;
        //return Google;
    }

    public static string DoOperation(CompanyDelegate companyDelegate)
    {
        return companyDelegate();
    }

    public static string Microsoft()
    {
        string name = "Microsfot";
        return name;
    }

    public static string Google()
    {
        string name = "Google";
        return name;
    }

    public static string Amazon()
    {
        string name = "Amazon";
        return name;
    }
}

class Program
{

    static void Main()
    {
        Methods.GenericDelegate<double> genericDelegate = Methods.OrdinaryMethod;
        genericDelegate += Methods.GenericMethod;

        genericDelegate(5.4321);
        // Console.WriteLine(genericDelegate(5.6136)); to works it you should set return type in your delegate ( Bad: delegate void GenericDelegate<T>(T value); )
        //                                                                                                     ( Good delegate T GenericDelegate<T>(T value);    )

        string company = String.Empty;

        company = Company.DoOperation(Company.Amazon);
        company = Company.DoOperation(Company.Google);
        company = Company.DoOperation(Company.Microsoft);

        Console.WriteLine(company);
        Console.WriteLine();
        //CompanyDelegate companyDelegate = Company.GetOperation();

        Console.WriteLine();
        Company.TestMethod();
    }
}