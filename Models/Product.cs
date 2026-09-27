namespace FoodOrderingSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int Likes { get; set; } = 0;
        public bool IsAvailable { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}