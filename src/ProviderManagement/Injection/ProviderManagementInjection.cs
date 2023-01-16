using Microsoft.Extensions.DependencyInjection;
using ProviderManagement.Providers;
using ProviderManagement.Providers.Factory;
using ProviderManagement.Sync;
using ProviderManagement.Sync.Interfaces;

namespace ProviderManagement.Injection
{
    public static class ProviderManagementInjection
    {
        public static IServiceCollection InjectProviderManagementServices(this IServiceCollection services) => services
            .AddTransient<IProviderServiceFactory, ProviderServiceFactory>()
            .AddTransient<IProviderSyncService, ProviderSyncService>()
            .AddTransient<IProviderSyncFinancialInstitutionService, ProviderSyncFinancialInstitutionService>()
            .AddTransient<IProviderSyncAssetService, ProviderSyncAssetService>();
    }
}