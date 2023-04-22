using Ecommerce.Server.Services.AuthService;
using Ecommerce.Server.Services.CartService;
using Ecommerce.Server.Services.OrdersService;
using Ecommerce.Server.Services.UsersService;
using Ecommerce.Shared.Models.Data;
using Stripe;
using Stripe.Checkout;

namespace BlazorEcommerce.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartService;
        private readonly IUsersService _usersService;
        private readonly IAuthService _authService;
        private readonly IOrdersService _orderService;

        const string secret = "whsec_cq1WH9CX9U1zxU9EpbBVvWOhfb6e5ysR";

        public PaymentService(ICartService cartService,
            IUsersService usersService,
            IAuthService authService,
            IOrdersService orderService)
        {
            StripeConfiguration.ApiKey = "sk_test_51HnFFuJWja1dketA1LY3VQds3XWpByD5GE8laKrxyNldWKnXXdktvITJiG3PYNDMwpSkrAv33d7JjvHDEUGPPo2E00vkDMlVIb";

            _cartService = cartService;
            _usersService = usersService;
            _authService = authService;
            _orderService = orderService;
        }

        public async Task<Session> CreateCheckoutSession()
        {
            var products = (await _cartService.GetDbCartProducts()).Data;
            var lineItems = new List<SessionLineItemOptions>();
            products.ForEach(product => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = product.Price * 100,
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.Title,
                        Images = new List<string> { product.ImageUrl }
                    }
                },
                Quantity = product.Quantity
            }));

            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUserEmail(),
                ShippingAddressCollection =
                    new SessionShippingAddressCollectionOptions
                    {
                        AllowedCountries = new List<string> { "US" }
                    },
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7226/order-success",
                CancelUrl = "https://localhost:7226/cart"
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }

        public async Task<ServiceResponseRecord<bool>> FulfillOrder(HttpRequest request)
        {
            var json = await new StreamReader(request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                        json,
                        request.Headers["Stripe-Signature"],
                        secret
                    );

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var user = await _usersService.GetUserByEmailAsync(session.CustomerEmail);
                    await _orderService.PlaceOrder(user.Id);
                }

                return new ServiceResponseRecord<bool> { Data = true };
            }
            catch (StripeException e)
            {
                return new ServiceResponseRecord<bool> { Data = false, Success = false, Message = e.Message };
            }
        }
    }
}
