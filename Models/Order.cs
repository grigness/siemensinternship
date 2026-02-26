namespace ConsoleApp1.Models;
//2.1
class Order
{
    public int OrderId { get; set; }
    public required Customer Customer { get; set; }
    public List<OrderItem> Items { get; set; } = new();

    //2.2
    public decimal CalculateFinalPrice()
    {
        decimal total = Items.Sum(i => i.Subtotal);
        return total > 500 ? total * 0.90m : total;
    }
}
