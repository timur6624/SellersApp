namespace ProfitService.Dtos;

public class ProductDto
{
    public Guid Id { get; set; }
    public decimal BuyPrice { get; set; }
    public decimal SellPrice { get; set; }
    public DateTime CreatedAt { get; set; } 
}