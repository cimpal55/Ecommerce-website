using Ecommerce.Data;
using Ecommerce.Migrations.Interfaces;
using FluentMigrator;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Migrations._20230419_Initial
{
    internal sealed class UserAddressesMigration : ISubMigration
    {
        private const string TableName = Tables.UserAddresses;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(UserAddresses.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(UserAddresses.UserId).AsInt32().NotNullable().ForeignKey(Tables.Users, Users.Id)
                .WithColumn(UserAddresses.FirstName).AsString(100).NotNullable()
                .WithColumn(UserAddresses.LastName).AsString(100).NotNullable()
                .WithColumn(UserAddresses.Street).AsString(300).NotNullable()
                .WithColumn(UserAddresses.City).AsString(100).NotNullable()
                .WithColumn(UserAddresses.State).AsString(100).NotNullable()
                .WithColumn(UserAddresses.Zip).AsString(50).NotNullable().WithDefault(SystemMethods.CurrentDateTime)
                .WithColumn(UserAddresses.CountryId).AsInt32().NotNullable().ForeignKey(Tables.ProductTypes, Countries.Id)
                .WithColumn(UserAddresses.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
