using FluentMigrator;

namespace Infra.Database.Postgres.Migrations
{
    [Migration(20230108163700)]
    public class AssetTable : Migration
    {
        public override void Up()
        {
            Create.Table("Asset")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("FinancialInstitutionId").AsInt32().NotNullable();

            Create.ForeignKey()
                .FromTable("Asset").ForeignColumn("FinancialInstitutionId")
                .ToTable("FinancialInstitution").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.Table("Asset");
        }
    }
}