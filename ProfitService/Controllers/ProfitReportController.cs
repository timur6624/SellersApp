using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfitService.Data;
using ProfitService.Dtos;

namespace ProfitService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
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
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var httpClient = _httpClientFactory.CreateClient("ProductService");
        
        // Передаём токен авторизации при обращении к ProductService
        var accessToken = Request.Headers["Authorization"].ToString();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Replace("Bearer ", ""));

        var response = await httpClient.GetAsync("/api/product");

        if (!response.IsSuccessStatusCode)
            return StatusCode(500, "ProductService unavailable");

        var products = await response.Content.ReadFromJsonAsync<List<ProductDto>>();

        if (products is null)
            return StatusCode(500, "Failed to parse products");

        var totalProfit = products.Sum(p => p.SellPrice - p.BuyPrice);
        var monthlyProfit = products
            .Where(p => p.CreatedAt.Month == DateTime.UtcNow.Month && p.CreatedAt.Year == DateTime.UtcNow.Year)
            .Sum(p => p.SellPrice - p.BuyPrice);

        return Ok(new
        {
            TotalProfit = totalProfit,
            MonthlyProfit = monthlyProfit
        });
    }
}