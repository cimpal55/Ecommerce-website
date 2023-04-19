using Ecommerce.Migrations.Interfaces;
using Ecommerce.Migrations.Utils.Extensions;
using FluentMigrator;

namespace Ecommerce.Migrations
{
    public abstract class CompositeMigration : Migration, ICompositeMigration
    {
        public sealed override void Up() =>
            this.RunUp(this);
        public sealed override void Down() =>
            this.RunDown(this);
        public abstract ISubMigration[] GetMigrations();
    }
}