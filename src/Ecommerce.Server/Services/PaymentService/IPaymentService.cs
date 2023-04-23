using Ecommerce.Shared.Models.Data;
using Stripe.Checkout;

namespace BlazorEcommerce.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();
        Task<ServiceResponseRecord<bool>> FulfillOrder(HttpRequest request);
    }
}
