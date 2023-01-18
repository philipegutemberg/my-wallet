using FluentMigrator;
using Infra.Database.Postgres.Consts;

namespace Infra.Database.Postgres.Migrations
{
    [Migration(20230108163600)]
    public class FinancialInstitutionTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.FinancialInstitution)
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table(Tables.FinancialInstitution);
        }
    }
}