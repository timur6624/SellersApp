namespace ProfitService.Models;

public class ProfitReport
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public decimal TotalProfit { get; set; }
    public decimal MonthlyProfit { get; set; }
    public DateTime ReportDate { get; set; } = DateTime.UtcNow;
}