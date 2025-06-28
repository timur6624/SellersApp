namespace ProductService.Dtos;

public class ProductResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal BuyPrice { get; set; }
    public decimal SellPrice { get; set; }
    public decimal Profit { get; set; } 
    public DateTime CreatedAt { get; set; }
}