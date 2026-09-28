namespace FoodOrderingSystem.DTOs;

public class CreateLoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}