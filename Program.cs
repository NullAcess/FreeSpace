delegate Closure Closure();

class Program
{
    static Closure OutFunc()
    {
        int x = 5;

        Closure Inner()
        {
            x++;
            Console.WriteLine(x);
            return Inner;
        }

        return Inner;
    }

    static void Main()
    {
        Closure func = OutFunc();

        func(); 
        func(); 
        func(); 
    }
}