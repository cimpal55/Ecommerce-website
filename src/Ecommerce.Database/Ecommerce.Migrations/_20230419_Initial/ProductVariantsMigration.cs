using Ecommerce.Data;
using Ecommerce.Migrations.Interfaces;
using Ecommerce.Migrations.Utils.Extensions;
using Ecommerce.Shared.Models.Data;
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
                .WithColumn(ProductVariants.OriginalPrice).AsDecimal(18, 2).Nullable()
                .WithColumn(ProductVariants.Visible).AsByte().Nullable()
                .WithColumn(ProductVariants.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 1, ProductTypeId = 2, Price = 9.99m, OriginalPrice = 19.99m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 1, ProductTypeId = 3, Price = 7.99m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 1, ProductTypeId = 4, Price = 19.99m, OriginalPrice = 29.99m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 2, ProductTypeId = 2, Price = 7.99m, OriginalPrice = 14.99m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 3, ProductTypeId = 2, Price = 6.99m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 4, ProductTypeId = 5, Price = 3.99m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 4, ProductTypeId = 6, Price = 9.99m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 4, ProductTypeId = 7, Price = 19.99m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 5, ProductTypeId = 5, Price = 3.99m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 6, ProductTypeId = 5, Price = 2.99m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 7, ProductTypeId = 8, Price = 19.99m, OriginalPrice = 29.99m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 7, ProductTypeId = 9, Price = 69.99m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 7, ProductTypeId = 10, Price = 49.99m, OriginalPrice = 59.99m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 8, ProductTypeId = 8, Price = 9.99m, OriginalPrice = 24.99m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 9, ProductTypeId = 8, Price = 14.99m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 10, ProductTypeId = 1, Price = 159.99m, OriginalPrice = 299m });
            migration.Insert.IntoTable(TableName)
                .Row(new { ProductId = 11, ProductTypeId = 1, Price = 79.99m, OriginalPrice = 399m });
        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
