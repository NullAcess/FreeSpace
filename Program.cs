class Company : IComparable<Company>
{
    public decimal Money { get; private set; }

    public Company(decimal money)
    {
        Money = money;
    }

    public int CompareTo(Company company)
    {
        if (company == null) return 1;
        return this.Money.CompareTo(company.Money) ;
    }
}

class CompanyByMoneyComparer : IComparer<Company>
{
    public int Compare(Company firstCompany, Company secondCompany)
    {
        if (firstCompany == null && secondCompany == null) return 0;
        if (firstCompany == null) return -1;
        if (secondCompany == null) return 1;
        
        return secondCompany.Money.CompareTo(firstCompany.Money);
    }
}

class Program
{
    static void Main()
    {
        int[] array = { 5, 3, 6, 1, 7 };
        Array.Sort(array);

        var compareObject = new CompanyByMoneyComparer();

        var microsoft = new Company(12345);
        var google = new Company(123456);
        var amazon = new Company(123456);
        var yandex = new Company(1234);
        yandex = null;

        int result = microsoft.CompareTo(google);
        int resultInverse = google.CompareTo(microsoft);
        int resultEqual = google.CompareTo(amazon);
        int nullResult = microsoft.CompareTo(yandex);
        Console.WriteLine(result);
        Console.WriteLine(resultInverse);
        Console.WriteLine(resultEqual);
        Console.WriteLine(nullResult);

        int newResult = compareObject.Compare(microsoft, google);
        Console.WriteLine($"\n{newResult}");

        var companies = new List<Company>
            {
                new Company(12),
                new Company(123),
                new Company(1234)
            };

        companies.Sort();
        foreach (var c in companies) Console.WriteLine(c.Money);

        companies.Sort(new CompanyByMoneyComparer());
        foreach (var c in companies) Console.WriteLine(c.Money);
    }
}