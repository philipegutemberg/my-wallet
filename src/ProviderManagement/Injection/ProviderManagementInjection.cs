using Microsoft.Extensions.DependencyInjection;
using ProviderManagement.Providers;
using ProviderManagement.Providers.Factory;
using ProviderManagement.Services;

namespace ProviderManagement.Injection
{
    public static class ProviderManagementInjection
    {
        public static IServiceCollection InjectProviderManagementServices(this IServiceCollection services) => services
            .AddTransient<IProviderServiceFactory, ProviderServiceFactory>()
            .AddTransient<IProviderSyncService, ProviderSyncService>();
    }
}