using Ecommerce.Data;
using Ecommerce.Migrations.Interfaces;
using FluentMigrator;
using static Ecommerce.Data.Columns;

namespace Ecommerce.Migrations._20230419_Initial
{
    internal sealed class UsersMigration : ISubMigration
    {
        private const string TableName = Tables.Users;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(Users.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Users.Email).AsString(250).NotNullable()
                .WithColumn(Users.PasswordHash).AsBinary().NotNullable()
                .WithColumn(Users.PasswordSalt).AsBinary().NotNullable()
                .WithColumn(Users.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
