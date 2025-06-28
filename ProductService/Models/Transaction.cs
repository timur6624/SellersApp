namespace ProductService.Models;

public class Transaction
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
public enum TransactionType { Buy, Sell }