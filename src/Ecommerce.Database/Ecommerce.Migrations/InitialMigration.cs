using Ecommerce.Migrations._20230419_Initial;
using Ecommerce.Migrations.Interfaces;
using FluentMigrator;

namespace Ecommerce.Migrations
{
    [TimestampedMigration(2023, 04, 19, 0, 0, "Initial migration")]
    public sealed class InitialMigration : CompositeMigration
    {
        public override ISubMigration[] GetMigrations() =>
            new ISubMigration[]
            {
                new CountriesMigration(),
                new ProductTypesMigration(),
                new UsersMigration(),
                new UserAddressesMigration(),
                new CategoriesMigration(),
                new ProductsMigration(),
                new ProductVariantsMigration(),
                new ImagesMigration(),
                new CartItemsMigration(),
                new OrdersMigration(),
                new OrderItemsMigration()
            };
    }
}
