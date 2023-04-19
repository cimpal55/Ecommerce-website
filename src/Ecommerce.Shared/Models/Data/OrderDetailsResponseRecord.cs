namespace Ecommerce.Shared.Models.Data
{
    public class OrderDetailsResponseRecord
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderDetailsProductResponseRecord> Products { get; set; } = new();
    }
}
