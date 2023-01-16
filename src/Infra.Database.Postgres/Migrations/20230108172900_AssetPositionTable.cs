using FluentMigrator;

namespace Infra.Database.Postgres.Migrations
{
    [Migration(20230108172900)]
    public class AssetPositionTable : Migration
    {
        public override void Up()
        {
            Create.Table("AssetPosition")
                .WithColumn("AssetId").AsInt32().PrimaryKey()
                .WithColumn("FinancialPosition").AsDecimal().NotNullable()
                .WithColumn("AppliedValue").AsDecimal().NotNullable()
                .WithColumn("Profitability").AsDecimal().NotNullable()
                .WithColumn("PortfolioPercentage").AsDecimal().NotNullable();

            Create.ForeignKey()
                .FromTable("AssetPosition").ForeignColumn("AssetId")
                .ToTable("Asset").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.Table("AssetPosition");
        }
    }
}