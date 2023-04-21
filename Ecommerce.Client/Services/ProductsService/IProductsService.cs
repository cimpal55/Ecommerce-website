using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Server.Services.ProductsService
{
    public interface IProductsService
    {
        Task InsertProductsAsync(ProductsRecord item);
        Task UpdateProductsAsync(ProductsRecord item);
        Task DeleteProductsAsync(ProductsRecord item);
        Task<ServiceResponseRecord<ProductsRecord>> CreateProduct(ProductsRecord product);
        Task<ServiceResponseRecord<bool>> DeleteProduct(int productId);
        Task<ServiceResponseRecord<List<ProductsRecord>>> GetAdminProducts();
        Task<ServiceResponseRecord<List<ProductsRecord>>> GetFeaturedProducts();
        Task<ServiceResponseRecord<ProductsRecord>> GetProductAsync(int productId);
        Task<ServiceResponseRecord<List<ProductsRecord>>> GetProductsAsync();
        Task<ServiceResponseRecord<List<ProductsRecord>>> GetProductsByCategory(string categoryUrl);
        Task<ServiceResponseRecord<List<string>>> GetProductSearchSuggestions(string searchText);
        Task<ServiceResponseRecord<ProductSearchRecord>> SearchProducts(string searchText, int page);
        Task<ServiceResponseRecord<ProductsRecord>> UpdateProduct(ProductsRecord product);
        Task<List<ProductsRecord>> FindProductsBySearchText(string searchText);
    }
}
