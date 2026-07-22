interface IMyCloneable<T>
{
    T Clone();
}

class OrderItem
{
    public string Title { get; private set; }
    public decimal Price { get; private set; }

    public OrderItem(string title, decimal price)
    {
        Title = title;
        Price = price;
    }
}

class Order : IMyCloneable<Order>
{
    public int Id { get; set; }
    public List<OrderItem> Items { get; private set; } = new List<OrderItem>();

    public Order Clone()
    {
        
        Order order = (Order)MemberwiseClone();
        order.Items = Items.Select(item => new OrderItem(item.Title, item.Price)).ToList();

        return order;
    }
}

class Program
{
    static void Main()
    {
        var order1 = new Order();
        order1.Id = 5;
        Console.WriteLine(order1.Id);
        var mouse = new OrderItem("mouse", 20);
        var laptop = new OrderItem("laptop", 500);

        order1.Items.Add(mouse);
        order1.Items.Add(laptop);

        var order2 = new Order();
        order2 = order1?.Clone();
        order2?.Items.Add(laptop);
        order2?.Id = 6;
        Console.WriteLine(order2?.Id);
        Console.WriteLine(order1?.Id);

        for (int i = 0; i < order2?.Items?.Count; i++)
        {
            Console.Write($"{order2.Items[i].Title} ");
        }
        Console.WriteLine();
        for (int i = 0; i < order1?.Items?.Count; i++)
        {
            Console.Write($"{order1.Items[i].Title} ");
        }
    }
}