using ConsoleApp1.Models;

namespace ConsoleApp1.Services;

class OrderService
{
    private List<Order> _orders;

    public OrderService(List<Order> orders)
    {
        _orders = orders;
    }

    //2.3
    public string GetTopSpender()
    {
        return _orders
            .GroupBy(o => o.Customer)
            .Select(g => new
            {
                Name = g.Key.Name,
                Total = g.Sum(o => o.CalculateFinalPrice())
            })
            .OrderByDescending(x => x.Total)
            .FirstOrDefault()?.Name ?? "No customers found";
    }

    //2.4
    public List<(string ProductName, int TotalSold)> GetPopularProducts()
    {
        return _orders
            .SelectMany(o => o.Items)
            .GroupBy(i => i.ProductName)
            .Select(g => (
                ProductName: g.Key,
                TotalSold: g.Sum(i => i.Quantity)
            ))
            .OrderByDescending(x => x.TotalSold)
            .ToList();
    }
}
