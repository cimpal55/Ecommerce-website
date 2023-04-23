using Ecommerce.Client;
using Ecommerce.Client.Services.AddressService;
using Ecommerce.Client.Services.AuthService;
using Ecommerce.Client.Services.CartService;
using Ecommerce.Client.Services.CategoryService;
using Ecommerce.Client.Services.OrderService;
using Ecommerce.Client.Services.ProductService;
using Ecommerce.Client.Services.ProductTypeService;
using Microsoft.AspNetCore.Components.Authorization;

namespace Ecommerce.Utils.ServiceRegistration
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddEcommerceServices(this IServiceCollection @this) =>
            @this
                .AddSqlServices();
        private static IServiceCollection AddSqlServices(this IServiceCollection @this) =>
            @this
                .AddScoped<IAddressService, AddressService>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<ICartService, CartService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IProductTypeService, ProductTypeService>()
                .AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>()
                .AddScoped<IProductService, ProductService>();
    }
}
