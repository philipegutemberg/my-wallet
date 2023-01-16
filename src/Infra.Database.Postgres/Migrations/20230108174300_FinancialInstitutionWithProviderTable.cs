using FluentMigrator;

namespace Infra.Database.Postgres.Migrations
{
    [Migration(20230108174300)]
    public class FinancialInstitutionWithProviderTable : Migration
    {
        public override void Up()
        {
            Create.Table("ProviderFinancialInstitution")
                .WithColumn("FinancialInstitutionId").AsInt32().NotNullable()
                .WithColumn("ProviderId").AsInt32().NotNullable()
                .WithColumn("ExternalIdOnProvider").AsString().NotNullable();

            Create.ForeignKey()
                .FromTable("ProviderFinancialInstitution").ForeignColumn("FinancialInstitutionId")
                .ToTable("FinancialInstitution").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.Table("ProviderFinancialInstitution");
        }
    }
}