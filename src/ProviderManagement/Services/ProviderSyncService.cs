using System.Threading.Tasks;
using ProviderManagement.Enums;
using ProviderManagement.Providers;
using ProviderManagement.Providers.Factory;

namespace ProviderManagement.Services
{
    internal class ProviderSyncService : IProviderSyncService
    {
        private readonly IProviderServiceFactory _providerServiceFactory;

        public ProviderSyncService(IProviderServiceFactory providerServiceFactory)
        {
            _providerServiceFactory = providerServiceFactory;
        }

        public async Task Sync(EnumProvider provider)
        {
            IProviderService providerService = _providerServiceFactory.Get(provider);

            var positions = await providerService.GetPositions();
            var movements = await providerService.GetMovements();
            var events = await providerService.GetEvents();
        }
    }
}