using Domain.Repositories;
using FluentMigrator.Runner;
using Infra.Database.Postgres.Connection;
using Infra.Database.Postgres.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProviderManagement.Repositories;

namespace Infra.Database.Postgres.Injection
{
    public static class PostgresInjector
    {
        public static IServiceCollection InjectPostgresServices(this IServiceCollection services, IConfiguration configuration) => services
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddPostgres()
                .WithGlobalConnectionString(configuration.GetConnectionString("InvestingWallet"))
                .ScanIn(typeof(AssetTable).Assembly).For.Migrations()
            )
            .AddTransient<DbConnectionFactory>()
            .AddTransient<DbConnection>()
            .AddTransient<IFinancialInstitutionRepository, FinancialInstitutionRepository>()
            .AddTransient<IAssetRepository, AssetRepository>()
            .AddTransient<IAssetPositionRepository, AssetPositionRepository>()
            .AddTransient<IProviderFinancialInstitutionRepository, ProviderFinancialInstitutionRepository>()
            .AddTransient<IProviderAssetRepository, ProviderAssetRepository>()
            .AddTransient<IPortfolioDimensionRepository, PortfolioDimensionRepository>()
            .AddTransient<IPortfolioAllocationRepository, PortfolioAllocationRepository>();
    }
}