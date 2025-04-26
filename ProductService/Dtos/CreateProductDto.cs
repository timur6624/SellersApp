namespace ProductService.Dtos;

public class CreateProductDto
{
    public string Name { get; set; }
    public decimal BuyPrice { get; set; }
    public decimal SellPrice { get; set; }
}