using Ecommerce.Data;
using LinqToDB.Mapping;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Shared.Models.Data
{
    [Table(Tables.Categories)]
    public class CategoriesRecord
    {
        [Column(Categories.Id)]
        public int Id { get; set; }

        [Column(Categories.Name)]
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        [Column(Categories.Visible)]
        public bool Visible { get; set; } = true;

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public bool Editing { get; set; } = false;
    }
}
