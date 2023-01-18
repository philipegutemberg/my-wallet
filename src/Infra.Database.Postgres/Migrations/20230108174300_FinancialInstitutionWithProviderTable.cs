using FluentMigrator;
using Infra.Database.Postgres.Consts;

namespace Infra.Database.Postgres.Migrations
{
    [Migration(20230108174300)]
    public class FinancialInstitutionWithProviderTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.ProviderFinancialInstitution)
                .WithColumn("financialinstitutionid").AsInt32().NotNullable()
                .WithColumn("providerid").AsInt32().NotNullable()
                .WithColumn("externalidonprovider").AsString().NotNullable();

            Create.ForeignKey()
                .FromTable(Tables.ProviderFinancialInstitution).ForeignColumn("financialinstitutionid")
                .ToTable(Tables.FinancialInstitution).PrimaryColumn("id");
        }

        public override void Down()
        {
            Delete.Table(Tables.ProviderFinancialInstitution);
        }
    }
}