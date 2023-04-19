using Ecommerce.Data;
using Ecommerce.Migrations.Interfaces;
using FluentMigrator;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Migrations._20230419_Initial
{
    internal sealed class CountriesMigration : ISubMigration
    {
        private const string TableName = Tables.Countries;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(Countries.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Countries.Name).AsString(300).NotNullable()
                .WithColumn(Countries.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
