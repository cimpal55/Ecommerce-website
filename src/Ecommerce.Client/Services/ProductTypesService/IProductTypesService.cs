using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Client.Services.ProductTypesService
{
    public interface IProductTypesService
    {
        Task InsertProductTypesAsync(ProductTypesRecord item);
        Task DeleteProductTypesAsync(ProductTypesRecord item);
        Task UpdateProductTypesAsync(ProductTypesRecord item);
        Task<ServiceResponseRecord<List<ProductTypesRecord>>> AddProductType(ProductTypesRecord productType);
        Task<ServiceResponseRecord<List<ProductTypesRecord>>> GetProductTypes();
        Task<ServiceResponseRecord<List<ProductTypesRecord>>> UpdateProductType(ProductTypesRecord productType);
    }
}
