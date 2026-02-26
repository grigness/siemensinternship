namespace ConsoleApp1.Models;
//2.1
class OrderItem
{
    public required string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPriceAtPurchase { get; set; }

    public decimal Subtotal => Quantity * UnitPriceAtPurchase;
}
