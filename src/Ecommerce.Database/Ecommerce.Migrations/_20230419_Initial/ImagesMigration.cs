using Ecommerce.Data;
using Ecommerce.Migrations.Interfaces;
using FluentMigrator;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Migrations._20230419_Initial
{
    internal sealed class ImagesMigration : ISubMigration
    {
        private const string TableName = Tables.Images;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(Images.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Images.Data).AsString(1000).NotNullable()
                .WithColumn(Images.ProductId).AsInt32().NotNullable().ForeignKey(Tables.Products, Products.Id)
                .WithColumn(Images.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
