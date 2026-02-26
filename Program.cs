using ConsoleApp1.Models;
using ConsoleApp1.Services;

class Program
{
    static void Main(string[] args)
    {
        Customer c1 = new Customer
        {
            CustomerID = 1,
            Name = "Ana"
        };

        Order order1 = new Order
        {
            OrderId = 1,
            Customer = c1
        };

        order1.Items.Add(new OrderItem
        {
            ProductName = "Mouse",
            Quantity = 2,
            UnitPriceAtPurchase = 350m
        });

        c1.Orders.Add(order1);

        OrderService orderService = new OrderService(new List<Order> { order1 });

        decimal finalPrice = order1.CalculateFinalPrice();
        Console.WriteLine("Customer 1: " + c1.Name);
        Console.WriteLine($"Final price for Order {order1.OrderId}: {finalPrice:C}");
        Console.WriteLine($"Top spender: {orderService.GetTopSpender()}");
        
        Console.WriteLine(string.Join("\n", orderService.GetPopularProducts().Select(x=>$"Most sold product: {x.ProductName} - Total Sold: {x.TotalSold}")));
    }
}


