using Ecommerce.Data;
using LinqToDB.Mapping;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Shared.Models.Data
{
    [Table(Tables.Images)]
    public sealed record ImagesRecord
    {
        [Column(Images.Id)]
        public int Id { get; set; }
        
        [Column(Images.Data)]
        public string Data { get; set; } = string.Empty;
    }
}
