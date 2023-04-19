using Ecommerce.Data;
using Ecommerce.Migrations.Interfaces;
using FluentMigrator;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Migrations._20230419_Initial
{
    internal sealed class CartItemsMigration : ISubMigration
    {
        private const string TableName = Tables.CartItems;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(CartItems.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(CartItems.UserId).AsInt32().NotNullable().ForeignKey(Tables.Users, Users.Id)
                .WithColumn(CartItems.ProductId).AsInt32().NotNullable().ForeignKey(Tables.Products, Products.Id)
                .WithColumn(CartItems.ProductTypeId).AsInt32().NotNullable().ForeignKey(Tables.ProductTypes, ProductTypes.Id)
                .WithColumn(CartItems.Quantity).AsInt32().NotNullable()
                .WithColumn(CartItems.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
