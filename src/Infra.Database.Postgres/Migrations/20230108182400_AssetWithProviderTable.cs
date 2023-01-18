using FluentMigrator;
using Infra.Database.Postgres.Consts;

namespace Infra.Database.Postgres.Migrations
{
    [Migration(20230108182400)]
    public class AssetWithProviderTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.ProviderAsset)
                .WithColumn("assetid").AsInt32().NotNullable()
                .WithColumn("providerid").AsInt32().NotNullable()
                .WithColumn("externalidonprovider").AsString().NotNullable();

            Create.ForeignKey()
                .FromTable(Tables.ProviderAsset).ForeignColumn("assetid")
                .ToTable(Tables.Asset).PrimaryColumn("id");
        }

        public override void Down()
        {
            Delete.Table(Tables.ProviderAsset);
        }
    }
}