namespace ProfitService.Dtos;

public class ProfitResponseDto
{
    public Decimal TotalProfit { get; set; }
    public Decimal MonthlyProfit { get; set; }
    public DateTime GeneratedAt;

}