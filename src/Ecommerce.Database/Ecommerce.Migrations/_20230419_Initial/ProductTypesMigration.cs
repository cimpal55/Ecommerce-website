using Ecommerce.Data;
using Ecommerce.Migrations.Interfaces;
using Ecommerce.Migrations.Utils.Extensions;
using Ecommerce.Shared.Models.Data;
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

            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "Default" });
            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "Paperback" });
            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "E-book" });
            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "Audiobook" });
            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "Stream" });
            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "Blu-ray" });
            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "VHS" });
            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "PC" });
            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "PlayStation" });
            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "Xbox" });
        }

        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
