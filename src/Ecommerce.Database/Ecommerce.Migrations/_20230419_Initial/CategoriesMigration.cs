using Ecommerce.Data;
using Ecommerce.Migrations.Interfaces;
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
                .WithColumn(Categories.Visible).AsByte().NotNullable()
                .WithColumn(Categories.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
