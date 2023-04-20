using Ecommerce.Data;
using Ecommerce.Migrations.Interfaces;
using Ecommerce.Migrations.Utils.Extensions;
using Ecommerce.Shared.Models.Data;
using FluentMigrator;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Migrations._20230419_Initial
{
    internal sealed class CategoriesMigration : ISubMigration
    {
        private const string TableName = Tables.Categories;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(Categories.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Categories.Name).AsString(300).NotNullable()
                .WithColumn(Categories.Visible).AsByte().Nullable()
                .WithColumn(Categories.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "Books" });
            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "Movies" });
            migration.Insert.IntoTable(TableName)
                .Row(new { Name = "Video Games" });
        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
