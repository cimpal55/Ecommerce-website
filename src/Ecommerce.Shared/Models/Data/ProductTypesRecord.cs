using Ecommerce.Data;
using LinqToDB.Mapping;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Shared.Models.Data
{
    [Table(Tables.ProductTypes)]
    public sealed record ProductTypesRecord
    {
        [Column(ProductTypes.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [Column(ProductTypes.Name, CanBeNull = false)]
        public string Name { get; set; } = string.Empty;
        public bool Editing { get; set; } = false;
        public bool IsNew { get; set; } = false;

    }
}
