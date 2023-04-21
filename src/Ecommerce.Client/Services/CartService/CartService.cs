using Ecommerce.Client.Services.AuthService;
using Ecommerce.Shared.Models.Data;
using LinqToDB;
using Ecommerce.Client.DbAccess;

namespace Ecommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly SqlDataAccess _conn;

        private readonly IAuthService _authService;
        public CartService(SqlDataAccess conn, IAuthService authService)
        {
            _conn = conn;
            _authService = authService;
        }
        public async Task InsertCartAsync(CartItemsRecord item) =>
            await _conn
                    .InsertAsync(item)
                    .ConfigureAwait(false);
        public async Task UpdateCartAsync(CartItemsRecord item) =>
            await _conn
                    .UpdateAsync(item)
                    .ConfigureAwait(false);
        public async Task DeleteCartAsync (CartItemsRecord item) =>
           await _conn
                   .DeleteAsync(item)
                   .ConfigureAwait(false);
        public async Task<ServiceResponseRecord<List<CartProductResponseRecord>>> GetCartProducts(List<CartItemsRecord> cartItems)
        {
            var result = new ServiceResponseRecord<List<CartProductResponseRecord>>
            {
                Data = new List<CartProductResponseRecord>()
            };

            foreach (var item in cartItems)
            {
                var product = await _conn.Products
                    .Where(p => p.Id == item.ProductId)
                    .FirstOrDefaultAsync();

                if (product == null)
                {
                    continue;
                }

                var productVariant = await _conn.ProductVariants
                    .Where(v => v.ProductId == item.ProductId
                        && v.ProductTypeId == item.ProductTypeId)
                    .LoadWith(v => v.ProductType)
                    .FirstOrDefaultAsync();

                if (productVariant == null)
                {
                    continue;
                }

                var cartProduct = new CartProductResponseRecord
                {
                    ProductId = product.Id,
                    Title = product.Title,
                    ImageUrl = product.ImageUrl,
                    Price = productVariant.Price,
                    ProductType = productVariant.ProductType.Name,
                    ProductTypeId = productVariant.ProductTypeId,
                    Quantity = item.Quantity
                };

                result.Data.Add(cartProduct);
            }

            return result;
        }

        public async Task<ServiceResponseRecord<List<CartProductResponseRecord>>> StoreCartItems(List<CartItemsRecord> cartItems)
        {
            cartItems.ForEach(cartItem => cartItem.UserId = _authService.GetUserId());
            foreach (CartItemsRecord cartItem in cartItems)
                await InsertCartAsync(cartItem).ConfigureAwait(false);

            return await GetDbCartProducts();
        }

        public async Task<ServiceResponseRecord<int>> GetCartItemsCount()
        {
            var count = (await _conn.CartItems.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync()).Count;
            return new ServiceResponseRecord<int> { Data = count };
        }

        public async Task<ServiceResponseRecord<List<CartProductResponseRecord>>> GetDbCartProducts(int? userId = null)
        {
            if (userId == null)
                userId = _authService.GetUserId();

            return await GetCartProducts(await _conn.CartItems
                .Where(ci => ci.UserId == userId).ToListAsync());
        }

        public async Task<ServiceResponseRecord<bool>> AddToCart(CartItemsRecord cartItem)
        {
            cartItem.UserId = _authService.GetUserId();

            var sameItem = await _conn.CartItems
                .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId &&
                ci.ProductTypeId == cartItem.ProductTypeId && ci.UserId == cartItem.UserId);
            if (sameItem == null)
            {
                await InsertCartAsync(cartItem).ConfigureAwait(false);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
                await UpdateCartAsync(sameItem);
            }

            return new ServiceResponseRecord<bool> { Data = true };
        }
        
        public async Task<ServiceResponseRecord<bool>> UpdateQuantity(CartItemsRecord cartItem)
        {
            var dbCartItem = await _conn.CartItems
                .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId &&
                ci.ProductTypeId == cartItem.ProductTypeId && ci.UserId == _authService.GetUserId());
            if (dbCartItem == null)
            {
                return new ServiceResponseRecord<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exist."
                };
            }

            dbCartItem.Quantity = cartItem.Quantity;
            await UpdateCartAsync(dbCartItem);

            return new ServiceResponseRecord<bool> { Data = true };
        }

        public async Task<ServiceResponseRecord<bool>> RemoveItemFromCart(int productId, int productTypeId)
        {
            var dbCartItem = await _conn.CartItems
                .FirstOrDefaultAsync(ci => ci.ProductId == productId &&
                ci.ProductTypeId == productTypeId && ci.UserId == _authService.GetUserId());
            if (dbCartItem == null)
            {
                return new ServiceResponseRecord<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exist."
                };
            }

            await DeleteCartAsync(dbCartItem).ConfigureAwait(false);

            return new ServiceResponseRecord<bool> { Data = true };
        }
    }
}
