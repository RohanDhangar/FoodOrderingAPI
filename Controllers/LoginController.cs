using FoodOrderingSystem.Data;
using FoodOrderingSystem.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace FoodOrderingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]

public class LoginController : ControllerBase
{
      private readonly AppDbContext _db;
    private readonly IConfiguration _configuration;

    public LoginController(AppDbContext db, IConfiguration configuration)
    {
        _db = db;
        _configuration = configuration;
    }

    [HttpPost]

     public async Task<IActionResult> LoginUser(CreateRegisterRequest request)
    {
        if (request.Email == "" || request.Password == "")
        {
            return BadRequest("Please provide the required email address and password");
        }

        var user = await _db.Users.FirstOrDefaultAsync(p => p.Email == request.Email);

        if(user == null)
        {
            return BadRequest("User does not exist, please register to the app");
        }

        bool isPasswordValid = BC.EnhancedVerify(request.Password, user.Password);

        if(!isPasswordValid)
        {
            return BadRequest("Invalid password, please provide the valid password");
        }

        

    }
}