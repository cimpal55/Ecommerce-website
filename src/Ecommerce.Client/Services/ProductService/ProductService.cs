using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public List<ProductsRecord> Products { get; set; } = new();
        public string Message { get; set; } = "Loading products...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;
        public List<ProductsRecord> AdminProducts { get; set; }

        public event Action ProductsChanged;

        public async Task<ProductsRecord> CreateProduct(ProductsRecord product)
        {
            var result = await _http.PostAsJsonAsync("api/product", product);
            var newProduct = (await result.Content
                .ReadFromJsonAsync<ServiceResponseRecord<ProductsRecord>>()).Data;
            return newProduct;
        }

        public async Task DeleteProduct(ProductsRecord product)
        {
            var result = await _http.DeleteAsync($"api/product/{product.Id}");
        }

        public async Task GetAdminProducts()
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponseRecord<List<ProductsRecord>>>("api/product/admin");
            AdminProducts = result.Data;
            CurrentPage = 1;
            PageCount = 0;
            if (AdminProducts.Count == 0)
                Message = "No products found.";
        }

        public async Task<ServiceResponseRecord<ProductsRecord>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponseRecord<ProductsRecord>>($"api/product/{productId}");
            return result;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponseRecord<List<ProductsRecord>>>("api/product/featured") :
                await _http.GetFromJsonAsync<ServiceResponseRecord<List<ProductsRecord>>>($"api/product/category/{categoryUrl}");
            if (result != null && result.Data != null)
                Products = result.Data;

            CurrentPage = 1;
            PageCount = 0;

            if (Products.Count == 0)
                Message = "No products found";

            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponseRecord<List<string>>>($"api/product/searchsuggestions/{searchText}");
            return result.Data;
        }

        public async Task SearchProducts(string searchText, int page)
        {
            LastSearchText = searchText;
            var result = await _http
                 .GetFromJsonAsync<ServiceResponseRecord<ProductSearchRecord>>($"api/product/search/{searchText}/{page}");
            if (result != null && result.Data != null)
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
            if (Products.Count == 0) Message = "No products found.";
            ProductsChanged?.Invoke();
        }

        public async Task<ProductsRecord> UpdateProduct(ProductsRecord product)
        {
            var result = await _http.PutAsJsonAsync($"api/product", product);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponseRecord<ProductsRecord>>();
            return content.Data;
        }
    }
}
