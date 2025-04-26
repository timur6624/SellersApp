namespace ProductService.Models;

public class Product
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; } // Владелец товара 
    public string Name { get; set; }

    public decimal BuyPrice { get; set; } // Цена покупки
    public decimal SellPrice { get; set; } // Цена продажи
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}