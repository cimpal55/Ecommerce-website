 namespace Ecommerce.Migrations.Interfaces
{
    public interface ICompositeMigration
    {
        ISubMigration[] GetMigrations();
    }
}
