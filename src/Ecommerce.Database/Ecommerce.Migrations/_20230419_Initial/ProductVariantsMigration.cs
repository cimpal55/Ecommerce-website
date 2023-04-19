using Ecommerce.Data;
using Ecommerce.Migrations.Interfaces;
using FluentMigrator;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Migrations._20230419_Initial
{
    internal sealed class ProductVariantsMigration : ISubMigration
    {
        private const string TableName = Tables.ProductVariants;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(ProductVariants.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(ProductVariants.ProductId).AsInt32().NotNullable().ForeignKey(Tables.Products, Products.Id)
                .WithColumn(ProductVariants.ProductTypeId).AsInt32().NotNullable().ForeignKey(Tables.ProductTypes, ProductTypes.Id)
                .WithColumn(ProductVariants.Price).AsDecimal(18,2).NotNullable()
                .WithColumn(ProductVariants.OriginalPrice).AsDecimal(18, 2).NotNullable()
                .WithColumn(ProductVariants.Visible).AsByte().NotNullable()
                .WithColumn(ProductVariants.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
