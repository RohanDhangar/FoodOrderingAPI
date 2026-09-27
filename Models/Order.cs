namespace FoodOrderingSystem.Models
{
    public class Order
    {
        public int Id {get; set;}
        public int UserId {get; set;}
        public decimal TotalAmount {get; set;}
        public string Status {get; set;} =string.Empty;
        public string PaymentMode {get; set;} = string.Empty;

        public DateTime UpdatedAt {get; set;}
        public User User {get; set;} = null!;

        public ICollection<OrderItem> OrderItem = new List<OrderItem>(); 
    }
}