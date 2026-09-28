using FoodOrderingSystem.Data;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly AppDbContext _db;

    public AddressController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]

    public async Task<IActionResult> GetAddresses(int UserId)
    {
        var addresses = await _db.Addresses.Where(a => a.UserId == UserId).ToListAsync();

        if(addresses == null || addresses.Count == 0)
        {
            return NotFound("No addresses found.");
        }

        return Ok(addresses);
    }

    [HttpPost]

    public async Task<IActionResult> CreateAddress(CreateAddressRequest request)
    {
        
    }
}