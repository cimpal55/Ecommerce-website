using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;
        List<ProductsRecord> Products { get; set; }
        List<ProductsRecord> AdminProducts { get; set; }
        string Message { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        string LastSearchText { get; set; }
        Task GetProducts(string? categoryUrl = null);
        Task<ServiceResponseRecord<ProductsRecord>> GetProduct(int productId);
        Task SearchProducts(string searchText, int page);
        Task<List<string>> GetProductSearchSuggestions(string searchText);
        Task GetAdminProducts();
        Task<ProductsRecord> CreateProduct(ProductsRecord product);
        Task<ProductsRecord> UpdateProduct(ProductsRecord product);
        Task DeleteProduct(ProductsRecord product);
    }
}
