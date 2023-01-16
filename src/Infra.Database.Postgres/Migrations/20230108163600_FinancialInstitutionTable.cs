using FluentMigrator;

namespace Infra.Database.Postgres.Migrations
{
    [Migration(20230108163600)]
    public class FinancialInstitutionTable : Migration
    {
        public override void Up()
        {
            Create.Table("FinancialInstitution")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("FinancialInstitution");
        }
    }
}