using Microsoft.Extensions.DependencyInjection;
using ProviderManagement.Entities;
using ProviderManagement.Providers.Factory;
using ProviderManagement.Sync;
using ProviderManagement.Sync.Context;
using ProviderManagement.Sync.Entities.Asset;
using ProviderManagement.Sync.Entities.AssetPosition;
using ProviderManagement.Sync.Entities.FinancialInstitution;
using ProviderManagement.Sync.Interfaces;

namespace ProviderManagement.Injection
{
    public static class ProviderManagementInjection
    {
        public static IServiceCollection InjectProviderManagementServices(this IServiceCollection services) => services
            .AddTransient<IProviderServiceFactory, ProviderServiceFactory>()
            .AddTransient<IProviderSyncService, ProviderSyncService>()
            .AddScoped<ISyncContext, SyncContext>()
            .AddTransient<ISyncableEntityService<SyncableAssetWithProvider>, AssetService>()
            .AddTransient<ISyncableEntityService<SyncableFinancialInstitutionWithProvider>, FinancialInstitutionService>()
            .AddTransient<ISyncableEntityService<SyncableAssetPosition>, AssetPositionService>()
            .AddTransient<IAssetSyncService, AssetSyncService>()
            .AddTransient<IAssetPositionSyncService, AssetPositionSyncService>()
            .AddTransient<IFinancialInstitutionSyncService, FinancialInstitutionSyncService>();
    }
}