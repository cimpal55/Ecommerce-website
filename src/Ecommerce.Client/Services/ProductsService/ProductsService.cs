using Ecommerce.Client.Services.UtilsService;
using Ecommerce.Shared.Models.Data;
using LinqToDB;
using Microsoft.AspNetCore.Http;
using Ecommerce.Client.DbAccess;
using System.Data.Entity;

namespace Ecommerce.Client.Services.ProductsService
{
    public class ProductsService : IProductsService
    {
        private readonly SqlDataAccess _conn;

        private readonly IUtilsService _utils;
        
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductsService(SqlDataAccess conn, IUtilsService utils, IHttpContextAccessor httpContextAccessor)
        {
            _conn = conn;
            _utils = utils;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task InsertProductsAsync(ProductsRecord item) =>
             await _conn
                .InsertAsync(item)
                .ConfigureAwait(false);

        public async Task UpdateProductsAsync(ProductsRecord item) =>
            await _conn
                .UpdateAsync(item)
                .ConfigureAwait(false);
        public async Task DeleteProductsAsync(ProductsRecord item) =>
            await _conn
                .DeleteAsync(item)
                .ConfigureAwait(false);

        public async Task<ServiceResponseRecord<ProductsRecord>> CreateProduct(ProductsRecord product)
        {
            foreach (var variant in product.Variants)
            {
                variant.ProductType = null;
            }
            await InsertProductsAsync(product).ConfigureAwait(false);
            return new ServiceResponseRecord<ProductsRecord> { Data = product };
        }

        public async Task<ServiceResponseRecord<bool>> DeleteProduct(int productId)
        {
            var dbProduct = await _conn.Products.Where(x => x.Id == productId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (dbProduct == null)
            {
                return new ServiceResponseRecord<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Product not found."
                };
            }
            dbProduct.Deleted = true;

            await UpdateProductsAsync(dbProduct).ConfigureAwait(false);
            
            return new ServiceResponseRecord<bool> { Data = true };
        }

        public async Task<ServiceResponseRecord<List<ProductsRecord>>> GetAdminProducts()
        {
            var response = new ServiceResponseRecord<List<ProductsRecord>>
            {          
                Data = await LinqToDB.AsyncExtensions.ToListAsync(_conn.Products
                    .Where(p => !p.Deleted)
                    .Include(p => p.Variants.Where(v => !v.Deleted))
                    .Include(p => p.Images))
        };

            return response;
        }

        public async Task<ServiceResponseRecord<List<ProductsRecord>>> GetFeaturedProducts()
        {
            var response = new ServiceResponseRecord<List<ProductsRecord>>
            {
                Data = await _conn.Products
                    .Where(p => p.Featured && p.Visible && !p.Deleted)
                    .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                    .Include(p => p.Images)
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponseRecord<ProductsRecord>> GetProductAsync(int productId)
        {
            var response = new ServiceResponseRecord<ProductsRecord>();
            ProductsRecord product = null;

            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _conn.Products
                    .Include(p => p.Variants.Where(v => !v.Deleted))
                    .Include(p => p.Images)
                    .FirstOrDefaultAsync(p => p.Id == productId && !p.Deleted);
            }
            else
            {
                product = await _conn.Products
                    .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                    .Include(p => p.Images)
                    .FirstOrDefaultAsync(p => p.Id == productId && !p.Deleted && p.Visible);
            }

            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this product does not exist.";
            }
            else
            {
                response.Data = product;
            }

            return response;
        }

        public async Task<ServiceResponseRecord<List<ProductsRecord>>> GetProductsAsync()
        {
            var response = new ServiceResponseRecord<List<ProductsRecord>>
            {
                Data = await _conn.Products
                    .Where(p => p.Visible && !p.Deleted)
                    .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                    .Include(p => p.Images)
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponseRecord<List<ProductsRecord>>> GetProductsByCategory(string categoryUrl)
        {
            var response = new ServiceResponseRecord<List<ProductsRecord>>
            {
                 Data = await _conn.Products
                    .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()) &&
                        p.Visible && !p.Deleted)
                    .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                    .Include(p => p.Images)
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponseRecord<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var products = await FindProductsBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if (product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponseRecord<List<string>> { Data = result };
        }

        public async Task<ServiceResponseRecord<ProductSearchRecord>> SearchProducts(string searchText, int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindProductsBySearchText(searchText)).Count / pageResults);
            var products = await _conn.Products
                                .Where(p => p.Title.ToLower().Contains(searchText.ToLower()) ||
                                    p.Description.ToLower().Contains(searchText.ToLower()) &&
                                    p.Visible && !p.Deleted)
                                .Include(p => p.Variants)
                                .Include(p => p.Images)
                                .Skip((page - 1) * (int)pageResults)
                                .Take((int)pageResults)
                                .ToListAsync();

            var response = new ServiceResponseRecord<ProductSearchRecord>
            {
                Data = new ProductSearchRecord
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };

            return response;
        }

        public async Task<ServiceResponseRecord<ProductsRecord>> UpdateProduct(ProductsRecord product)
        {
            var dbProduct = await _conn.Products
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            if (dbProduct == null)
            {
                return new ServiceResponseRecord<ProductsRecord>
                {
                    Success = false,
                    Message = "Product not found."
                };
            }

            dbProduct.Title = product.Title;
            dbProduct.Description = product.Description;
            dbProduct.ImageUrl = product.ImageUrl;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.Visible = product.Visible;
            dbProduct.Featured = product.Featured;

            var productImages = dbProduct.Images;
            foreach (ImagesRecord productImage in productImages)
                await _utils.DeleteImageAsync(productImage).ConfigureAwait(false);

            dbProduct.Images = product.Images;

            foreach (var variant in product.Variants)
            {
                var dbVariant = await _conn.ProductVariants
                    .SingleOrDefaultAsync(v => v.ProductId == variant.ProductId &&
                        v.ProductTypeId == variant.ProductTypeId);
                if (dbVariant == null)
                {
                    variant.ProductType = null;
                    await _utils.InsertProductVariantsAsync(variant).ConfigureAwait(false);
                }
                else
                {
                    dbVariant.ProductTypeId = variant.ProductTypeId;
                    dbVariant.Price = variant.Price;
                    dbVariant.OriginalPrice = variant.OriginalPrice;
                    dbVariant.Visible = variant.Visible;
                    dbVariant.Deleted = variant.Deleted;
                    await _utils.UpdateProductVariantsAsync(dbVariant);
                }
            }

            await UpdateProductsAsync(dbProduct).ConfigureAwait(false);
            return new ServiceResponseRecord<ProductsRecord> { Data = product };
        }

        public async Task<List<ProductsRecord>> FindProductsBySearchText(string searchText)
        {
            return await _conn.Products
                                .Where(p => p.Title.ToLower().Contains(searchText.ToLower()) ||
                                    p.Description.ToLower().Contains(searchText.ToLower()) &&
                                    p.Visible && !p.Deleted)
                                .Include(p => p.Variants)
                                .ToListAsync();
        }
    }
}
