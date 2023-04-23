using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Client.Services.OrderService
{
    public interface IOrderService
    {
        Task<string> PlaceOrder();
        Task<List<OrderOverviewResponseRecord>> GetOrders();
        Task<OrderDetailsResponseRecord> GetOrderDetails(int orderId);
    }
}
