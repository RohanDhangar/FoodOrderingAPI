using FoodOrderingSystem.Data;
using FoodOrderingSystem.DTOs;
using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProductController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]

    public async Task<IActionResult> GetProducts()
    {
        var products = await _db.Products.ToListAsync();

        return Ok(products);
    }

    [HttpPost]

    public async Task<IActionResult> CreateProduct(CreateProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock,
            Likes = request.Likes ? 1 : 0,
            IsAvailable = request.Stock > 0,
            UpdatedAt = DateTime.UtcNow
        };

        _db.Products.Add(product);

        await _db.SaveChangesAsync();

        return Ok(product);
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);

        if(product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> UpdateProduct(CreateProductRequest request, int id)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);

        if(product == null)
        {
            return NotFound();
        }

        product.Name = request.Name;
        product.Description = request.Description;
        product.IsAvailable = (product.Stock+request.Stock) > 0;
        product.Stock = request.Stock;
        product.Price = request.Price;
        product.Likes = request.Likes ? product.Likes+1 : product.Likes; 
        product.UpdatedAt = DateTime.UtcNow;

        await _db.SaveChangesAsync();

        return Ok(product);
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);

        if(product == null)
        {
            return NotFound();
        }

        _db.Products.Remove(product);

        await _db.SaveChangesAsync();

        return NoContent();
    }
}