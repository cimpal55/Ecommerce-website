using Ecommerce.Server.Services.CartService;
using Ecommerce.Shared.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("products")]
        public async Task<ActionResult<ServiceResponseRecord<List<CartProductResponseRecord>>>> GetCartProducts(List<CartItemsRecord> cartItems)
        {
            var result = await _cartService.GetCartProducts(cartItems);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponseRecord<List<CartProductResponseRecord>>>> StoreCartItems(List<CartItemsRecord> cartItems)
        {
            var result = await _cartService.StoreCartItems(cartItems);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponseRecord<bool>>> AddToCart(CartItemsRecord cartItem)
        {
            var result = await _cartService.AddToCart(cartItem);
            return Ok(result);
        }

        [HttpPut("update-quantity")]
        public async Task<ActionResult<ServiceResponseRecord<bool>>> UpdateQuantity(CartItemsRecord cartItem)
        {
            var result = await _cartService.UpdateQuantity(cartItem);
            return Ok(result);
        }

        [HttpDelete("{productId}/{productTypeId}")]
        public async Task<ActionResult<ServiceResponseRecord<bool>>> RemoveItemFromCart(int productId, int productTypeId)
        {
            var result = await _cartService.RemoveItemFromCart(productId, productTypeId);
            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponseRecord<int>>> GetCartItemsCount()
        {
            return await _cartService.GetCartItemsCount();
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponseRecord<List<CartProductResponseRecord>>>> GetDbCartProducts()
        {
            var result = await _cartService.GetDbCartProducts();
            return Ok(result);
        }
    }
}
