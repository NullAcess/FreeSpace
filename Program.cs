using Microsoft.Win32.SafeHandles;
using System.Numerics;
using static Programs.Enumes;

namespace Programs
{
    class Enumes
    {
        public enum OperationType
        {
            Sum,
            Sum2
        }
    }

    class Person
    {
        public string Name { get; private set; } = "Andrew";

        public virtual void Print() => Console.WriteLine(Name);
    }
    class Manager : Person
    {
        public string Company { get; private set; } = "Microsoft";

        public override void Print() => Console.WriteLine(Company);
    }

    delegate Chain Chain(int value);
    delegate void PersonPrint();
    delegate T Operation<T>(T value1, T value2);
    delegate K Operation<T, K>(T value1, T value2);

    class Program
    {
        delegate void ManagerPrint();

        static Chain chainPrint(int id)
        {
            Console.WriteLine(id);
            return chainPrint;
        }

        static Operation<double> SelectOperation(OperationType opType)
        {
            switch (opType)
            {
                case OperationType.Sum: return Sum2;
                case OperationType.Sum2: return Sum<double>;
                default: return Sum2;
            }
        }

        static void DoAction(Operation<double> action)
        {
            Console.WriteLine(action(104.136, 555));
        }

        static T Sum<T>(T value1, T value2) where T : INumber<T>
        {
            T result = value1 + value2;
            return result;
        }

        static double Sum2(double value1, double value2)
        {
            double result = value1 + value2 + value2;
            Console.WriteLine(result);
            return result;
        }

        static T Sum5<T, K>(K value1, K value2)
            where K : INumber<K>
            where T : INumber<T>
        {
            K kSum = value1 + value2 + value2;
            T result = T.CreateChecked(kSum);
            Console.WriteLine(result);
            return result;
        }

        static void Sum4<T>(T value1, T value2) where T : INumber<T>
        {
            T rate = T.CreateChecked(2);
            T result = (T)((value1 + value2) * rate);
            Console.WriteLine(result);
        }

        //static void Sum3(ref double value1, int value2)
        //{
        //    double result = value1 + value2;
        //    Console.WriteLine(result);
        //> } БРАК НЕ ПОДХОДИТ НЕ ТЕ ПАРАМЕТРЫ

        static void Main()
        {
            var Andrew = new Person();

            Operation<double, double> operationPrintUltra = Sum;
            Operation<double> operationPrint = Sum;
            PersonPrint personPrint = Andrew.Print;
            ManagerPrint managerPrint = new Manager().Print;
            managerPrint = new ManagerPrint(new Manager().Print);

            personPrint();
            managerPrint();

            operationPrint(5, 10.5136);
            operationPrint = Sum2;
            operationPrint(34, 15.5136);
            //> operationPrint = Sum3; НЕ ПОДХОДИТ ПО ПАРАМЕТРАМ 

            Console.WriteLine();

            Operation<double>? defaulDelegate = Sum;
            Operation<double>? operationList = Sum;
            operationList -= Sum;
            operationList += Sum2;
            operationList -= Sum2;
            // double number = (operationList ?? defaulDelegate)(4,3); BAD BAD BAD
            //double number = operationList?.Invoke(4,3) ?? defaulDelegate(4,3); 
            //else Console.WriteLine("Erorr: oprList = null");
            operationList += Sum2;
            operationList += Sum;
            // operationList += Sum4; ошибка, не совпадение параметров ( void и double / T )
            Console.WriteLine(operationList(23, 27));
            //> operationList -= Andrew.Print; Ошибка, нету такого в группе методов делегаты ( такого метода нету )

            Console.WriteLine();

            Operation<double> generalDelegate = operationPrint + operationList + defaulDelegate;
            generalDelegate?.Invoke(55, 4135.513);

            Console.WriteLine();
            Console.WriteLine(operationPrintUltra(33333.136613, 3331));
            DoAction(operationPrint);

            operationPrint = SelectOperation(OperationType.Sum);
            operationPrint(4, 3);

            Console.WriteLine();
            chainPrint(4);
            chainPrint(5);
            chainPrint(10);
        }
    }

    // delegate void GeneralDelegate<T>(T value1, T value2); | | | | | | | ни к чему :(
}