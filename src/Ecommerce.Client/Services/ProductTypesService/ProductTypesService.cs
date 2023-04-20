using Ecommerce.Shared.Models.Data;
using LinqToDB;
using Ecommerce.Client.DbAccess;

namespace Ecommerce.Client.Services.ProductTypesService
{
    public class ProductTypesService : IProductTypesService
    {
        private readonly SqlDataAccess _conn;

        public ProductTypesService(SqlDataAccess conn)
        {
            _conn = conn;
        }
        public async Task InsertProductTypesAsync(ProductTypesRecord item) =>
             await _conn                          
                .InsertAsync(item)                
                .ConfigureAwait(false);                                                            
        public async Task UpdateProductTypesAsync(ProductTypesRecord item) =>
            await _conn                          
                .UpdateAsync(item)               
                .ConfigureAwait(false);          
        public async Task DeleteProductTypesAsync(ProductTypesRecord item) =>
            await _conn
                .DeleteAsync(item)
                .ConfigureAwait(false);

        public async Task<ServiceResponseRecord<List<ProductTypesRecord>>> AddProductType(ProductTypesRecord productType)
        {
            productType.Editing = productType.IsNew = false;
            
            await InsertProductTypesAsync(productType).ConfigureAwait(false);

            return await GetProductTypes();
        }

        public async Task<ServiceResponseRecord<List<ProductTypesRecord>>> GetProductTypes()
        {
            var productTypes = await _conn.ProductTypes.ToListAsync();
            return new ServiceResponseRecord<List<ProductTypesRecord>> { Data = productTypes };
        }
        public async Task<ServiceResponseRecord<List<ProductTypesRecord>>> UpdateProductType(ProductTypesRecord productType)
        {
            var dbProductType = await _conn.ProductTypes.Where(x => x.Id == productType.Id).FirstOrDefaultAsync();
            if (dbProductType == null)
            {
                return new ServiceResponseRecord<List<ProductTypesRecord>>
                {
                    Success = false,
                    Message = "Product Type not found."
                };
            }

            dbProductType.Name = productType.Name;
            await UpdateProductTypesAsync(dbProductType).ConfigureAwait(false);

            return await GetProductTypes();
        }
    }
}
