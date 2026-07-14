class CompanyException : Exception
{
    public string ExcMessageClass { get; private set; }
    public CompanyException(string message, string excMessageClass) : base(message) { ExcMessageClass = excMessageClass;  }
}

class Company
{
    private string id;

    public string Id
    {
        get { return id; }
        set
        {
            if (value[0] == 'r') throw new CompanyException("First letter of id is 'r'", "awggwa :foo");
            else id = value;
        }
    }

    public Company(string id) => Id = id;
}

class Program
{
    static void Main()
    {
        int[] numbers = new int[4];
        int x = 120;

        try
        {
            try
            {
                var oneC = new Company("r-1367f631");

                Console.Write("Enter your username: ");
                string userEnter = Console.ReadLine() ?? String.Empty;
                if (userEnter == null || userEnter.Length <= 2)
                {
                    throw new InvalidCastException("Invalid cast hehehaahh :) ");
                }
            }
            catch (InvalidCastException exc)
            {
                Console.WriteLine(exc.Message);
                Console.WriteLine(exc.StackTrace);
                throw;
            }
            catch (CompanyException exceptionCustom)
            {
                Console.Clear();
                Console.WriteLine("Exception, maybe this exception about invalid company ID");
                Console.WriteLine($"Foo message: {exceptionCustom.ExcMessageClass}");
            }
        }
        catch (InvalidCastException exc)
        {
            Console.WriteLine(exc.Message);
            Console.WriteLine("EXCEPTION NUMBER twooooo!!!");
        }
        finally
        {
            Console.WriteLine($"\n!! Don't worry !!");
        }

        //try
        //{
        //    int y = x / 0;

        //    Console.WriteLine($"Результат: {y}");
        //    numbers[33] = 99;
        //}
        //catch (DivideByZeroException)
        //{
        //    Console.WriteLine("Возникло исключение DivideByZeroException");
        //}
        //catch (IndexOutOfRangeException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
        //catch (Exception)
        //{
        //    Console.WriteLine("Exception"); // в конце, потому что catch будет использоваться первый подходящий
        //}
    }
}