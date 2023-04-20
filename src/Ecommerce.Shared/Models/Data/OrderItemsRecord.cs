using Ecommerce.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Shared.Models.Data
{
    [Table(Tables.OrderItems)]
    public sealed record OrderItemsRecord
    {
        public OrdersRecord Order { get; set; } = new();
        public int OrderId { get; set; }
        public ProductsRecord Product { get; set; } = new();
        public int ProductId { get; set; }
        public ProductTypesRecord ProductType { get; set; } = new();
        public int ProductTypeId { get; set; }
        public int Quantity { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
    }
}
