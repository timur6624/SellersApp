using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ProfitService.Data;
using ProfitService.Dtos;
using ProfitService.Models;

namespace ProfitService.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProfitReportController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly AppDbContext _context;

    public ProfitReportController(IHttpClientFactory httpClientFactory, AppDbContext context)
    {
        _httpClientFactory = httpClientFactory;
        _context = context;
    }

    [HttpGet("report")]

    public async Task<IActionResult> GetProfitReport()
    {
        var httpClient = _httpClientFactory.CreateClient("ProductService");
        var response = await httpClient.GetAsync("/api/product"); // без userId

        if (!response.IsSuccessStatusCode)
            return StatusCode(500, "ProductService unavailable");

        var products = await response.Content.ReadFromJsonAsync<List<ProductDto>>();

        if (products is null)
            return StatusCode(500, "Failed to parse products");

// 2. Считаем прибыль
        var totalProfit = products.Sum(p => p.SellPrice - p.BuyPrice);
        var monthlyProfit = products
            .Where(p => p.CreatedAt.Month == DateTime.UtcNow.Month && p.CreatedAt.Year == DateTime.UtcNow.Year)
            .Sum(p => p.SellPrice - p.BuyPrice);

// Вернуть что-то (например, объект с прибылью)
        return Ok(new
        {
            TotalProfit = totalProfit,
            MonthlyProfit = monthlyProfit
        });
    }
}