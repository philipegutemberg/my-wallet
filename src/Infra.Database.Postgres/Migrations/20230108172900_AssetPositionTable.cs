using FluentMigrator;
using Infra.Database.Postgres.Consts;

namespace Infra.Database.Postgres.Migrations
{
    [Migration(20230108172900)]
    public class AssetPositionTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.AssetPosition)
                .WithColumn("assetid").AsInt32().PrimaryKey()
                .WithColumn("financialposition").AsDecimal().NotNullable()
                .WithColumn("appliedvalue").AsDecimal().NotNullable()
                .WithColumn("profitability").AsDecimal().NotNullable()
                .WithColumn("portfoliopercentage").AsDecimal().NotNullable();

            Create.ForeignKey()
                .FromTable(Tables.AssetPosition).ForeignColumn("assetid")
                .ToTable(Tables.Asset).PrimaryColumn("id");
        }

        public override void Down()
        {
            Delete.Table(Tables.AssetPosition);
        }
    }
}