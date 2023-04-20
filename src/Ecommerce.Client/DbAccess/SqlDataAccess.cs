using Ecommerce.Shared.Models.Data;
using LinqToDB;
using LinqToDB.Data;

namespace Ecommerce.Client.DbAccess
{
    public class SqlDataAccess : DataConnection
    {
        public SqlDataAccess(LinqToDBConnectionOptions<SqlDataAccess> options)
            : base(options)
        {
        }
        public ITable<UsersRecord> Users => this.GetTable<UsersRecord>();
        public ITable<UserAddressesRecord> UserAddresses => this.GetTable<UserAddressesRecord>();
        public ITable<UserRegisterRecord> UserRegister => this.GetTable<UserRegisterRecord>();
        public ITable<UserLoginRecord> UserLogin => this.GetTable<UserLoginRecord>();
        public ITable<UserChangePasswordRecord> UserChangePassword => this.GetTable<UserChangePasswordRecord>();
        public ITable<ProductVariantsRecord> ProductVariants => this.GetTable<ProductVariantsRecord>();
        public ITable<ProductTypesRecord> ProductTypes => this.GetTable<ProductTypesRecord>();
        public ITable<ProductsRecord> Products => this.GetTable<ProductsRecord>();
        public ITable<ProductSearchRecord> ProductSearch => this.GetTable<ProductSearchRecord>();
        public ITable<OrdersRecord> Orders => this.GetTable<OrdersRecord>();
        public ITable<OrderOverviewResponseRecord> OrderOverviewResponse => this.GetTable<OrderOverviewResponseRecord>();
        public ITable<OrderItemsRecord> OrderItems => this.GetTable<OrderItemsRecord>();
        public ITable<OrderDetailsProductResponseRecord> OrderDetailsProductResponse => this.GetTable<OrderDetailsProductResponseRecord>();
        public ITable<OrderDetailsResponseRecord> OrderDetailsResponse => this.GetTable<OrderDetailsResponseRecord>();
        public ITable<ImagesRecord> Images => this.GetTable<ImagesRecord>();
        public ITable<CategoriesRecord> Categories => this.GetTable<CategoriesRecord>();
        public ITable<CartProductResponseRecord> CartProductResponse => this.GetTable<CartProductResponseRecord>();
        public ITable<CartItemsRecord> CartItems => this.GetTable<CartItemsRecord>();
    }
}
