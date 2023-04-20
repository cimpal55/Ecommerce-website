using Ecommerce.Data;
using System.ComponentModel.DataAnnotations.Schema;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Shared.Models.Data
{
    [Table(Tables.Orders)]
    public sealed record OrdersRecord
    {
        [Column(Orders.Id)]
        public int Id { get; set; }

        [Column(Orders.UserId)]
        public int UserId { get; set; }

        [Column(Orders.OrderDate)]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Column(Orders.TotalPrice)]
        public decimal TotalPrice { get; set; }
        public List<OrderItemsRecord> OrderItems { get; set; } = new();
    }
}
