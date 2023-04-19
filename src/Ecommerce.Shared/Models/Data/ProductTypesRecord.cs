using Ecommerce.Data;
using LinqToDB.Mapping;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Shared.Models.Data
{
    public class ProductTypesRecord
    {
        [Column(ProductTypes.Id)]
        public int Id { get; set; }

        [Column(ProductTypes.Name)]
        public string Name { get; set; } = string.Empty;

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public bool Editing { get; set; } = false;

    }
}
