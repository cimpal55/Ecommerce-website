using Ecommerce.Data;
using Ecommerce.Migrations.Interfaces;
using FluentMigrator;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Migrations._20230419_Initial
{
    internal sealed class OrdersMigration : ISubMigration
    {
        private const string TableName = Tables.Orders;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(Orders.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Orders.UserId).AsInt32().NotNullable().ForeignKey(Tables.Users, Users.Id)
                .WithColumn(Orders.OrderDate).AsDateTime2().NotNullable()
                .WithColumn(Orders.TotalPrice).AsDecimal(18, 2).NotNullable()
                .WithColumn(Orders.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
