using Ecommerce.Client.Services.AuthService;
using Ecommerce.Client.Services.CartService;
using Ecommerce.Shared.Models.Data;
using LinqToDB;
using Ecommerce.Client.DbAccess;

namespace Ecommerce.Client.Services.OrdersService
{
    public class OrdersService : IOrdersService
    {
        private readonly SqlDataAccess _conn;
        
        private readonly ICartService _cartService;
        
        private readonly IAuthService _authService;
        public OrdersService(SqlDataAccess conn,
            ICartService cartService,
            IAuthService authService)
        {
            _conn = conn;
            _cartService = cartService;
            _authService = authService;
        }
        public async Task InsertOrderAsync(OrdersRecord item) =>
            await _conn
                    .InsertAsync(item)
                    .ConfigureAwait(false);
        public async Task UpdateOrderAsync(OrdersRecord item) =>
            await _conn
                    .UpdateAsync(item)
                    .ConfigureAwait(false);
        public async Task DeleteOrderAsync(OrdersRecord item) =>
           await _conn
                   .DeleteAsync(item)
                   .ConfigureAwait(false);
        public async Task<ServiceResponseRecord<OrderDetailsResponseRecord>> GetOrderDetails(int orderId)
        {
            var response = new ServiceResponseRecord<OrderDetailsResponseRecord>();
            var order = await _conn.Orders
                .LoadWith(o => o.OrderItems)
                .ThenLoad(oi => oi.Product)
                .LoadWith(o => o.OrderItems)
                .ThenLoad(oi => oi.ProductType)
                .Where(o => o.UserId == _authService.GetUserId() && o.Id == orderId)
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync();        

            if (order == null)
            {
                response.Success = false;
                response.Message = "Order not found.";
                return response;
            }

            var orderDetailsResponse = new OrderDetailsResponseRecord
            {
                Products = new List<OrderDetailsProductResponseRecord>()
            };

            order.OrderItems.ForEach(item =>
            orderDetailsResponse.Products.Add(new OrderDetailsProductResponseRecord
            {
                ProductId = item.ProductId,
                ImageUrl = item.Product.ImageUrl,
                ProductType = item.ProductType.Name,
                Quantity = item.Quantity,
                Title = item.Product.Title,
                TotalPrice = item.TotalPrice
            }));

            response.Data = orderDetailsResponse;

            return response;
        }

        public async Task<ServiceResponseRecord<List<OrderOverviewResponseRecord>>> GetOrders()
        {
 
            var response = new ServiceResponseRecord<List<OrderOverviewResponseRecord>>();
            var orders = await _conn.Orders
                .LoadWith(o => o.OrderItems)
                .ThenLoad(oi => oi.Product)
                .Where(o => o.UserId == _authService.GetUserId())
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var orderResponse = new List<OrderOverviewResponseRecord>();
            orders.ForEach(o => orderResponse.Add(new OrderOverviewResponseRecord
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                Product = o.OrderItems.Count > 1 ?
                    $"{o.OrderItems.First().Product.Title} and" +
                    $" {o.OrderItems.Count - 1} more..." :
                    o.OrderItems.First().Product.Title,
                ProductImageUrl = o.OrderItems.First().Product.ImageUrl
            }));

            response.Data = orderResponse;

            return response;
        }

        public async Task<ServiceResponseRecord<bool>> PlaceOrder(int userId)
        {
            var products = (await _cartService.GetDbCartProducts(userId)).Data;
            decimal totalPrice = 0;
            products.ForEach(product => totalPrice += product.Price * product.Quantity);

            var orderItems = new List<OrderItemsRecord>();
            products.ForEach(product => orderItems.Add(new OrderItemsRecord
            {
                ProductId = product.ProductId,
                ProductTypeId = product.ProductTypeId,
                Quantity = product.Quantity,
                TotalPrice = product.Price * product.Quantity
            }));

            var order = new OrdersRecord
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };

            await InsertOrderAsync(order).ConfigureAwait(false);

            await _conn.CartItems.Where(ci => ci.UserId == userId).DeleteAsync().ConfigureAwait(false);;

            return new ServiceResponseRecord<bool> { Data = true };
        }
    }
}
