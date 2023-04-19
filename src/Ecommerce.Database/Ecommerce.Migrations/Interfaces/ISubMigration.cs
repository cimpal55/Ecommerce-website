using FluentMigrator;

namespace Ecommerce.Migrations.Interfaces
{
    public interface ISubMigration
    {
        void Up(Migration migration);
        void Down(Migration migration);
    }
}
