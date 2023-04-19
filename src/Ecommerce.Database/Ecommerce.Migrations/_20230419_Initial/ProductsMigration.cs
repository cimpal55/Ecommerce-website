using Ecommerce.Data;
using Ecommerce.Migrations.Interfaces;
using FluentMigrator;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Migrations._20230419_Initial
{
    internal sealed class ProductsMigration : ISubMigration
    {
        private const string TableName = Tables.Products;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(Products.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Products.Title).AsString(300).NotNullable()
                .WithColumn(Products.Description).AsString(1000).NotNullable()
                .WithColumn(Products.ImageUrl).AsString(600).NotNullable()
                .WithColumn(Products.CategoryId).AsInt32().NotNullable().ForeignKey(Tables.Categories, Categories.Id)
                .WithColumn(Products.Featured).AsByte().NotNullable()
                .WithColumn(Products.Visible).AsByte().NotNullable()
                .WithColumn(Products.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
