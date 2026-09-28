using FoodOrderingSystem.Data;
using FoodOrderingSystem.DTOs;
using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;


namespace FoodOrderingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RegisterController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IConfiguration _configuration;

    public RegisterController(AppDbContext db, IConfiguration configuration)
    {
        _db = db;
        _configuration = configuration;
    }

    [HttpPost]

    public async Task<IActionResult> RegisterUser(CreateRegisterRequest request)
    {
        if (request.Email == "" || request.Name == "" || request.Password == "")
        {
            return BadRequest("Please provide the required details");
        }

        var ExistingUser = await _db.Users.FirstOrDefaultAsync(p => p.Email == request.Email);

        if(ExistingUser != null)
        {
            return BadRequest("Please provide the valid email address. User already exist in the system with this email address");
        }

        int BcryptWorkFactor = _configuration.GetValue<int>("Authentication:BcryptWorkFactor");

        string tempPassword = request.Password;

        request.Password = BC.EnhancedHashPassword(tempPassword, BcryptWorkFactor);

        if (request.Password == "")
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                "Internal server error, password is not encrypting. Please try again later"
            );
        }

        var user = new User
        {
            Email = request.Email,
            Name = request.Name,
            Password = request.Password,
            CusinePreference = request.CusinePreference,
            UpdatedAt = DateTime.UtcNow,
            Addresses = new List<Address>()
        };

        _db.Users.Add(user);

        await _db.SaveChangesAsync();

        return Ok(new
        {
            Message = "User created successfully, please login into the app",
            Data = user
        });

    }
}