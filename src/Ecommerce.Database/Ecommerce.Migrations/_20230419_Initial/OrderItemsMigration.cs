using Ecommerce.Data;
using Ecommerce.Migrations.Interfaces;
using FluentMigrator;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Migrations._20230419_Initial
{
    internal sealed class OrderItemsMigration : ISubMigration
    {
        private const string TableName = Tables.OrderItems;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(OrderItems.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(OrderItems.OrderId).AsInt32().NotNullable().ForeignKey(Tables.Orders, Orders.Id)
                .WithColumn(OrderItems.ProductId).AsInt32().NotNullable().ForeignKey(Tables.Products, Products.Id)
                .WithColumn(OrderItems.ProductTypeId).AsInt32().NotNullable().ForeignKey(Tables.ProductTypes, ProductTypes.Id)
                .WithColumn(OrderItems.Quantity).AsInt32().NotNullable()
                .WithColumn(OrderItems.TotalPrice).AsDecimal(18, 2).NotNullable()
                .WithColumn(OrderItems.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
