using Ecommerce.Data;
using LinqToDB.Mapping;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Shared.Models.Data
{
    [Table(Tables.Products)]
    public sealed record ProductsRecord
    {
        [Column(Products.Id)]
        public int Id { get; set; }

        [Column(Products.Title)]
        public string Title { get; set; } = string.Empty;

        [Column(Products.Description)]
        public string Description { get; set; } = string.Empty;

        [Column(Products.ImageUrl)]
        public string ImageUrl { get; set; } = string.Empty;
        public List<ImagesRecord> Images { get; set; } = new();
        public CategoriesRecord? Category { get; set; }

        [Column(Products.CategoryId)]
        public int CategoryId { get; set; }

        [Column(Products.Featured)]
        public bool Featured { get; set; } = false;
        public List<ProductVariantsRecord> Variants { get; set; } = new();
        public bool Visible { get; set; } = true;

        public bool Deleted { get; set; } = false;

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public bool Editing { get; set; } = false;

    }
}
