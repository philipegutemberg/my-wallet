using FluentMigrator;

namespace Infra.Database.Postgres.Migrations
{
    [Migration(20221230194700)]
    public class AssetPositionProviderTable : Migration
    {
        public override void Up()
        {
            Create.Table("AssetPositionProvider")
                .WithColumn("AssetId").AsInt32()
                .WithColumn("ProviderId").AsInt32()
                .WithColumn("ProviderExternalId").AsString();
        }

        public override void Down()
        {
            Delete.Table("AssetPositionProvider");
        }
    }
}