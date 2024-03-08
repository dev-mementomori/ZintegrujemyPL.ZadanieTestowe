using FluentMigrator;

namespace ZintegrujemyPL.ZadanieTestowe.Infrastructure.Migrations
{
    [Migration(1)]
    public class InitialMigration : Migration
    {
        public override void Up()
        {
            if (!Schema.Table("Products").Exists())
            {
                Create.Table("Products")
                    .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                    .WithColumn("SKU").AsString().NotNullable()
                    .WithColumn("Name").AsString().NotNullable()
                    .WithColumn("EAN").AsString().Nullable()
                    .WithColumn("ProducerName").AsString().Nullable()
                    .WithColumn("Category").AsString().Nullable()
                    .WithColumn("DefaultImage").AsString(int.MaxValue).Nullable()
                    .WithColumn("IsWire").AsBoolean().NotNullable();
            }

            if (!Schema.Table("Inventory").Exists())
            {
                Create.Table("Inventory")
                    .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                    .WithColumn("SKU").AsString().NotNullable()
                    .WithColumn("Quantity").AsDecimal().NotNullable()
                    .WithColumn("Unit").AsString().NotNullable()
                    .WithColumn("ShippingCost").AsDecimal().NotNullable()
                    .WithColumn("ShippingTime").AsString().NotNullable();
            }

            if (!Schema.Table("Prices").Exists())
            {
                Create.Table("Prices")
                    .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                    .WithColumn("ProductSKU").AsString().NotNullable()
                    .WithColumn("NettProductPriceAfterDiscountForProductLogisticUnit").AsDecimal().NotNullable();
            }
        }

        public override void Down()
        {
            if (Schema.Table("Products").Exists())
            {
                Delete.Table("Products");
            }

            if (Schema.Table("Inventory").Exists())
            {
                Delete.Table("Inventory");
            }

            if (Schema.Table("Prices").Exists())
            {
                Delete.Table("Prices");
            }
        }
    }
}
