using Microsoft.EntityFrameworkCore;
using ProfitService.Models;

namespace ProfitService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<ProfitReport> ProfitReports { get; set; }
}