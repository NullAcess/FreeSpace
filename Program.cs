delegate bool ProductFilter(Product product);

class Product
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public ProductCategory Category { get; private set; }

    public Product(string name, decimal price, ProductCategory category)
    {
        Name = name;
        Price = price;
        Category = category;
    }
}

class DataEngine
{
    public static List<Product> Filter(List<Product> productsList, List<Product> passProductsList, ProductFilter productFilter)
    {
        for (int i = 0; i < productsList.Count; i++)
        {
            if (productFilter.Invoke(productsList[i])) passProductsList.Add(productsList[i]);
        }

        return passProductsList;
    }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>();
        List<Product> passProducts = new List<Product>();
        var orange = new Product("Orange", 100, ProductCategory.Fruits);
        var fish = new Product("Fish", 200, ProductCategory.Helthy);

        products.Add(orange); products.Add(fish);
            
        int priceCheck = 100; // ВВОД ПОЛЬЗОВАТЕЛЯ БУДЕТ ДОПУСТИМ
        ProductCategory productCategory = ProductCategory.Fruits; // ВВОД ПОЛЬЗОВАТЕЛЯ БУДЕТ ДОПУСТИМ

        DataEngine.Filter(products, passProducts, product => product.Price > priceCheck && product.Category == productCategory);

        for (int i = 0; i < passProducts.Count; i++)
        {
            Console.Write($"{passProducts[i].Name} ");
        }
    }
}

enum ProductCategory : byte
{
    None,
    Fruits,
    Helthy
}