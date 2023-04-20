using Ecommerce.Shared.Models.Data;
using LinqToDB;
using Ecommerce.Client.DbAccess;
using System.Linq.Expressions;

namespace Ecommerce.Client.Services.UtilsService
{
    public class UtilsService : IUtilsService
    {
        private readonly SqlDataAccess _conn;
        public UtilsService(SqlDataAccess conn)
        {
            _conn = conn;
        }
        public async Task InsertProductVariantsAsync(ProductVariantsRecord item) =>
            await _conn
                .InsertAsync(item)
                .ConfigureAwait(false);
        public async Task UpdateProductVariantsAsync(ProductVariantsRecord item) =>
            await _conn
                .UpdateAsync(item)
                .ConfigureAwait(false);
        public async Task DeleteImageAsync(ImagesRecord item) =>
            await _conn
                .DeleteAsync(item)
                .ConfigureAwait(false);

    }
}
