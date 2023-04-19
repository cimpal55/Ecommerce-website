using Ecommerce.Data;
using Ecommerce.Migrations.Interfaces;
using FluentMigrator;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Migrations._20230419_Initial
{
    internal sealed class ProductTypesMigration : ISubMigration
    {
        private const string TableName = Tables.ProductTypes;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(ProductTypes.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(ProductTypes.Name).AsString(300).NotNullable()
                .WithColumn(ProductTypes.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
