using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Server.Services.CartService
{
    public interface ICartService
    {
        Task InsertCartAsync(CartItemsRecord item);
        Task DeleteCartAsync(CartItemsRecord item);
        Task UpdateCartAsync(CartItemsRecord item);
        Task<ServiceResponseRecord<List<CartProductResponseRecord>>> GetCartProducts(List<CartItemsRecord> cartItems);
        Task<ServiceResponseRecord<List<CartProductResponseRecord>>> StoreCartItems(List<CartItemsRecord> cartItems);
        Task<ServiceResponseRecord<int>> GetCartItemsCount();
        Task<ServiceResponseRecord<List<CartProductResponseRecord>>> GetDbCartProducts(int? userId = null);
        Task<ServiceResponseRecord<bool>> AddToCart(CartItemsRecord cartItem);
        Task<ServiceResponseRecord<bool>> UpdateQuantity(CartItemsRecord cartItem);
        Task<ServiceResponseRecord<bool>> RemoveItemFromCart(int productId, int productTypeId);

    }
}
