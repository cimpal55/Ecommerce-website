using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Server.Services.UtilsService
{
    public interface IUtilsService
    {
        Task InsertProductVariantsAsync(ProductVariantsRecord item);
        Task UpdateProductVariantsAsync(ProductVariantsRecord item);
        Task DeleteImageAsync(ImagesRecord item);
    }
}
