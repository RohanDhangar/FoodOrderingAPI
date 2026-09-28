namespace FoodOrderingSystem.DTOs;

public class CreateRegisterRequest
{
    public string Name { get; set; } = string.Empty;
    public required string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public List<string> CusinePreference { get; set; } = new List<string>();
}