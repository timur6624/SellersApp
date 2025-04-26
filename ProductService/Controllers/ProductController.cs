using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Data;
using ProductService.Dtos;
using ProductService.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductService.Controllers;


[ApiController]
[Route("api/Product")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto dto)
    {
        // Получаем UserId из JWT-токена
        //var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var product = new Product
        {
            //UserId = userId,
            Name = dto.Name,
            BuyPrice = dto.BuyPrice,
            SellPrice = dto.SellPrice
        };

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        var response = new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            BuyPrice = product.BuyPrice,
            SellPrice = product.SellPrice,
            Profit = product.SellPrice - product.BuyPrice
        };

        return Ok(response);
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetMyProducts()
    {
        //var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var products = await _context.Products
            //.Where(p => p.UserId == userId)
            .Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                BuyPrice = p.BuyPrice,
                SellPrice = p.SellPrice,
                Profit = p.SellPrice - p.BuyPrice
            })
            .ToListAsync();

        return Ok(products);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        //var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id);// и юзер равенство юзер айди

        if (product == null)
            return NotFound("Товар не найден или не принадлежит вам");

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent(); // 204 No Content
    }
    
    
    
    
    
}