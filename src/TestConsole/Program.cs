using System;
using System.Globalization;
using System.Threading;
using ExternalServices.Kinvo.Injection;
using Infra.Database.Postgres.Injection;
using Microsoft.Extensions.DependencyInjection;
using ProviderManagement.Injection;

IServiceProvider provider = new ServiceCollection()
    .InjectKinvoServices()
    .InjectPostgresServices()
    .InjectProviderManagementServices()
    .BuildServiceProvider();

Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

var repo = provider.GetRequiredService<IPositionRepository>();

var response = await repo.GetWalletPosition();

var maxName = response.Assets.Max(a => a.Asset.Name.Length);

var totalFinancial = response.Assets.Sum(a => a.FinancialPosition);
var totalApplied = response.Assets.Sum(a => a.AppliedValue);

response.Assets.OrderByDescending(a => a.FinancialPosition).ToList().ForEach(a =>
{
    Console.WriteLine($@"
        {a.Asset.Name.PadRight(maxName, ' ')} | 
        {a.FinancialPosition.ToString("C2").PadLeft(12, ' ')} | 
        {(a.FinancialPosition / totalFinancial).ToString("P2").PadLeft(8, ' ')} |
        {(a.AppliedValue / totalApplied).ToString("P2").PadLeft(8, ' ')}".Replace(Environment.NewLine, " "));
});

response.Assets.GroupBy(a=> a.Asset.ClassName).ToList().ForEach(assetClass =>
{
    Console.WriteLine($"{assetClass.Key} | {assetClass.Sum(ac => ac.FinancialPosition).ToString("C2").PadLeft(12, ' ')} | {assetClass.Sum(ac => ac.WalletPercentage).ToString("P2").PadLeft(8, ' ')}");
});