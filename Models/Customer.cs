namespace ConsoleApp1.Models;
//2.1
class Customer
{
    public int CustomerID { get; set; }
    public required string Name { get; set; }
    public List<Order> Orders { get; set; } = new();
}
