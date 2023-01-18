using Domain.Repositories;
using ProviderManagement.Enums;
using ProviderManagement.Models;
using ProviderManagement.Providers;
using ProviderManagement.Providers.Factory;
using ProviderManagement.Sync.Context;
using ProviderManagement.Sync.Entities.Asset;
using ProviderManagement.Sync.Entities.AssetPosition;
using ProviderManagement.Sync.Entities.FinancialInstitution;
using ProviderManagement.Sync.Interfaces;

namespace ProviderManagement.Sync
{
    internal class ProviderSyncService : IProviderSyncService
    {
        private readonly ISyncContext _syncContext;
        private readonly IProviderServiceFactory _providerServiceFactory;
        private readonly IFinancialInstitutionSyncService _financialInstitutionSyncService;
        private readonly IAssetSyncService _assetSyncService;
        private readonly IAssetPositionSyncService _assetPositionSyncService;

        public ProviderSyncService(
            ISyncContext syncContext,
            IProviderServiceFactory providerServiceFactory,
            IFinancialInstitutionSyncService financialInstitutionSyncService,
            IAssetSyncService assetSyncService,
            IAssetPositionSyncService assetPositionSyncService
        )
        {
            _syncContext = syncContext;
            _providerServiceFactory = providerServiceFactory;
            _financialInstitutionSyncService = financialInstitutionSyncService;
            _assetSyncService = assetSyncService;
            _assetPositionSyncService = assetPositionSyncService;
        }

        public async Task Sync(EnumProvider providerId)
        {
            await SetPositionsOnContext(providerId);

            await _financialInstitutionSyncService.Sync();

            await _assetSyncService.Sync();

            await _assetPositionSyncService.Sync();

            // var movements = await providerService.GetMovements();
            // var events = await providerService.GetEvents();
        }

        private async Task SetPositionsOnContext(EnumProvider providerId)
        {
            IProviderService providerService = _providerServiceFactory.Get(providerId);
            var positions = await providerService.GetPositions();

            _syncContext.Add(ContextKeys.Positions, positions);
        }
    }
}