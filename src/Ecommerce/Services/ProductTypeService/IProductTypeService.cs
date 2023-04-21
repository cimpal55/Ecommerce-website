using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Client.Services.ProductTypeService
{
    public interface IProductTypeService
    {
        event Action OnChange;
        public List<ProductTypesRecord> ProductTypes { get; set; }
        Task GetProductTypes();
        Task AddProductType(ProductTypesRecord productType);
        Task UpdateProductType(ProductTypesRecord productType);
        ProductTypesRecord CreateNewProductType();
    }
}
