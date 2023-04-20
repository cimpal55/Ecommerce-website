using Ecommerce.Data;
using LinqToDB.Mapping;
using System.Text.Json.Serialization;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Shared.Models.Data
{
    [Table(Tables.ProductVariants)]
    public sealed record ProductVariantsRecord
    {
        [JsonIgnore]
        public int Id { get; set; }
        public ProductsRecord? Product { get; set; }

        [Column(ProductVariants.ProductId)]
        public int ProductId { get; set; }
        public ProductTypesRecord? ProductType { get; set; }

        [Column(ProductVariants.ProductTypeId)]
        public int ProductTypeId { get; set; }

        [Column(ProductVariants.Price)]
        public decimal Price { get; set; }

        [Column(ProductVariants.OriginalPrice)]
        public decimal OriginalPrice { get; set; }

        [Column(ProductVariants.Visible)]
        public bool Visible { get; set; } = true;

        public bool Deleted { get; set; } = false;

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public bool Editing { get; set; } = false;





    }
}
