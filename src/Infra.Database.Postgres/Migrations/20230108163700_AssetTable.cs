using FluentMigrator;
using Infra.Database.Postgres.Consts;

namespace Infra.Database.Postgres.Migrations
{
    [Migration(20230108163700)]
    public class AssetTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.Asset)
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("financialinstitutionid").AsInt32().NotNullable();

            Create.ForeignKey()
                .FromTable(Tables.Asset).ForeignColumn("financialinstitutionid")
                .ToTable(Tables.FinancialInstitution).PrimaryColumn("id");
        }

        public override void Down()
        {
            Delete.Table(Tables.Asset);
        }
    }
}