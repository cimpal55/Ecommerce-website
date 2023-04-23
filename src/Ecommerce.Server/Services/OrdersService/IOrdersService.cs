using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Server.Services.OrdersService
{
    public interface IOrdersService
    {
        Task InsertOrderAsync(OrdersRecord item);
        Task UpdateOrderAsync(OrdersRecord item);
        Task DeleteOrderAsync(OrdersRecord item);
        Task<ServiceResponseRecord<OrderDetailsResponseRecord>> GetOrderDetails(int orderId);
        Task<ServiceResponseRecord<List<OrderOverviewResponseRecord>>> GetOrders();
        Task<ServiceResponseRecord<bool>> PlaceOrder(int userId);
    }
}
