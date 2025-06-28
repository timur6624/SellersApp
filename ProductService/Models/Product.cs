namespace ProductService.Models;

public class Product
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }

    public decimal BuyPrice { get; set; } 
    public decimal SellPrice { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}