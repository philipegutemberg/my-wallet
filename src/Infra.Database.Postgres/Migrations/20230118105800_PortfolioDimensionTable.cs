using FluentMigrator;
using Infra.Database.Postgres.Consts;

namespace Infra.Database.Postgres.Migrations;

[Migration(20230118105800)]
public class PortfolioDimensionTable : Migration
{
    public override void Up()
    {
        Create.Table(Tables.PortfolioDimension)
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("parentdimensionid").AsInt32().Nullable();

        Create.ForeignKey()
            .FromTable(Tables.PortfolioDimension).ForeignColumn("parentdimensionid")
            .ToTable(Tables.PortfolioDimension).PrimaryColumn("id");

        Create.Column("portfoliodimensionid")
            .OnTable(Tables.Asset)
            .AsInt32().Nullable();

        Create.ForeignKey()
            .FromTable(Tables.Asset).ForeignColumn("portfoliodimensionid")
            .ToTable(Tables.PortfolioDimension).PrimaryColumn("id");
    }

    public override void Down()
    {
        Delete.ForeignKey()
            .FromTable(Tables.Asset).ForeignColumn("portfoliodimensionid")
            .ToTable(Tables.PortfolioDimension).PrimaryColumn("id");

        Delete.Column("portfoliodimensionid")
            .FromTable(Tables.Asset);

        Delete.Table(Tables.PortfolioDimension);
    }
}