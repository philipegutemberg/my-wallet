using FluentMigrator;
using Infra.Database.Postgres.Consts;

namespace Infra.Database.Postgres.Migrations;

[Migration(20230118105800)]
public class AssetDimensionTable : Migration
{
    public override void Up()
    {
        Create.Table(Tables.Dimension)
            .WithColumn("id").AsInt32().NotNullable()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("parentdimensionid").AsInt32().Nullable();

        Create.ForeignKey()
            .FromTable(Tables.Dimension).ForeignColumn("parentdimensionid")
            .ToTable(Tables.Dimension).PrimaryColumn("id");
    }

    public override void Down()
    {
        Delete.Table(Tables.Dimension);
    }
}