using Ecommerce.Client.Services.AddressService;
using Ecommerce.Client.Services.AuthService;
using Ecommerce.Client.Services.CartService;
using Ecommerce.Client.Services.CategoriesService;
using Ecommerce.Client.Services.OrdersService;
using Ecommerce.Client.Services.ProductsService;
using Ecommerce.Client.Services.ProductTypesService;
using Ecommerce.Client.Services.UsersService;
using Ecommerce.Client.Services.UtilsService;
using Microsoft.Extensions.DependencyInjection;

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
                .AddScoped<IUsersService, UsersService>()
                .AddScoped<ICartService, CartService>()
                .AddScoped<ICategoriesService, CategoriesService>()
                .AddScoped<IOrdersService, OrdersService>()
                .AddScoped<IProductTypesService, ProductTypesService>()
                .AddScoped<IProductsService, ProductsService>()
                .AddScoped<IUtilsService, UtilsService>()
                .AddScoped<ICartService, CartService>();
    }
}
