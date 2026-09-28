namespace FoodOrderingSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<string> CusinePreference { get; set; } = new List<string>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public DateTime UpdatedAt { get; set; }
    }
}