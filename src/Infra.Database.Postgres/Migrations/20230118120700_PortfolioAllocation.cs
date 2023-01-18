using FluentMigrator;
using Infra.Database.Postgres.Consts;

namespace Infra.Database.Postgres.Migrations;

[Migration(20230118120700)]
public class PortfolioAllocation : Migration
{
    public override void Up()
    {
        Create.Table(Tables.PortfolioAllocation)
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("percentage").AsDecimal().NotNullable()
            .WithColumn("dimensionid").AsInt32().Nullable()
            .WithColumn("assetid").AsInt32().Nullable();

        Create.ForeignKey()
            .FromTable(Tables.PortfolioAllocation).ForeignColumn("dimensionid")
            .ToTable(Tables.PortfolioDimension).PrimaryColumn("id");

        Create.ForeignKey()
            .FromTable(Tables.PortfolioAllocation).ForeignColumn("assetid")
            .ToTable(Tables.Asset).PrimaryColumn("id");
    }

    public override void Down()
    {
        Delete.Table(Tables.PortfolioAllocation);
    }
}