using Ecommerce.Data;
using LinqToDB.Mapping;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Shared.Models.Data
{
    [Table(Tables.CartItems)]
    public sealed record CartItemsRecord
    {
        [Column(CartItems.Id)]
        public int Id { get; set; }

        [Column(CartItems.UserId)]
        public int UserId { get; set; }
        
        [Column(CartItems.ProductId)]
        public int ProductId { get; set; }
        
        [Column(CartItems.ProductTypeId)]
        public int ProductTypeId { get; set; }

        [Column(CartItems.Quantity)]
        public int Quantity { get; set; } = 1;
    }
}
