using FluentMigrator;

namespace Infra.Database.Postgres.Migrations
{
    [Migration(20230108182400)]
    public class AssetWithProviderTable : Migration
    {
        public override void Up()
        {
            Create.Table("ProviderAsset")
                .WithColumn("AssetId").AsInt32().NotNullable()
                .WithColumn("ProviderId").AsInt32().NotNullable()
                .WithColumn("ExternalIdOnProvider").AsString().NotNullable();

            Create.ForeignKey()
                .FromTable("ProviderAsset").ForeignColumn("AssetId")
                .ToTable("Asset").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.Table("ProviderAsset");
        }
    }
}