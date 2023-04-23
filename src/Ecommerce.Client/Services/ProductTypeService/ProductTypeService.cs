using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Client.Services.ProductTypeService
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly HttpClient _http;
        public ProductTypeService(HttpClient http)
        {
            _http = http;
        }

        public List<ProductTypesRecord> ProductTypes { get; set; } = new();

        public event Action OnChange;

        public async Task AddProductType(ProductTypesRecord productType)
        {
            var response = await _http.PostAsJsonAsync("api/producttype", productType);
            ProductTypes = (await response.Content
                .ReadFromJsonAsync<ServiceResponseRecord<List<ProductTypesRecord>>>()).Data;
            OnChange.Invoke();
        }

        public ProductTypesRecord CreateNewProductType()
        {
            var newProductType = new ProductTypesRecord { IsNew = true, Editing = true };

            ProductTypes.Add(newProductType);
            OnChange.Invoke();
            return newProductType;
        }

        public async Task GetProductTypes()
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponseRecord<List<ProductTypesRecord>>>("api/producttype");
            ProductTypes = result.Data;
        }

        public async Task UpdateProductType(ProductTypesRecord productType)
        {
            var response = await _http.PutAsJsonAsync("api/producttype", productType);
            ProductTypes = (await response.Content
                .ReadFromJsonAsync<ServiceResponseRecord<List<ProductTypesRecord>>>()).Data;
            OnChange.Invoke();
        }
    }
}
