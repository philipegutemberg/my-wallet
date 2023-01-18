using System.Globalization;
using ExternalServices.Kinvo.Injection;
using FluentMigrator.Runner;
using Infra.Database.Postgres.Injection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProviderManagement.Enums;
using ProviderManagement.Injection;
using ProviderManagement.Sync.Interfaces;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

IServiceProvider provider = new ServiceCollection()
    .AddSingleton(configuration)
    .InjectKinvoServices()
    .InjectPostgresServices(configuration)
    .InjectProviderManagementServices()
    .AddLogging(lb => lb.AddFluentMigratorConsole())
    .BuildServiceProvider();

using (var scope = provider.CreateScope())
{
    var migrationRunner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    migrationRunner.MigrateUp();
}

Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

var sync = provider.GetRequiredService<IProviderSyncService>();

await sync.Sync(EnumProvider.Kinvo);

// var maxName = response.Assets.Max(a => a.Asset.Name.Length);
//
// var totalFinancial = response.Assets.Sum(a => a.FinancialPosition);
// var totalApplied = response.Assets.Sum(a => a.AppliedValue);
//
// response.Assets.OrderByDescending(a => a.FinancialPosition).ToList().ForEach(a =>
// {
//     Console.WriteLine($@"
//         {a.Asset.Name.PadRight(maxName, ' ')} |
//         {a.FinancialPosition.ToString("C2").PadLeft(12, ' ')} |
//         {(a.FinancialPosition / totalFinancial).ToString("P2").PadLeft(8, ' ')} |
//         {(a.AppliedValue / totalApplied).ToString("P2").PadLeft(8, ' ')}".Replace(Environment.NewLine, " "));
// });
//
// response.Assets.GroupBy(a=> a.Asset.ClassName).ToList().ForEach(assetClass =>
// {
//     Console.WriteLine($"{assetClass.Key} | {assetClass.Sum(ac => ac.FinancialPosition).ToString("C2").PadLeft(12, ' ')} | {assetClass.Sum(ac => ac.WalletPercentage).ToString("P2").PadLeft(8, ' ')}");
// });