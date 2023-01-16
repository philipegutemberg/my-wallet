using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using ProviderManagement.Entities;
using ProviderManagement.Enums;
using ProviderManagement.Providers;
using ProviderManagement.Providers.Factory;
using ProviderManagement.Repositories;
using ProviderManagement.Sync.Interfaces;
using ProviderAssetPosition = ProviderManagement.Models.ProviderAssetPosition;

namespace ProviderManagement.Sync
{
    internal class ProviderSyncService : IProviderSyncService
    {
        private readonly IProviderServiceFactory _providerServiceFactory;
        private readonly IProviderSyncFinancialInstitutionService _providerSyncFinancialInstitutionService;
        private readonly IProviderSyncAssetService _providerSyncAssetService;
        private readonly IAssetPositionRepository _assetPositionRepository;

        public ProviderSyncService(
            IProviderServiceFactory providerServiceFactory,
            IProviderSyncFinancialInstitutionService providerSyncFinancialInstitutionService,
            IProviderSyncAssetService providerSyncAssetService,
            IAssetPositionRepository assetPositionRepository
            )
        {
            _providerServiceFactory = providerServiceFactory;
            _providerSyncFinancialInstitutionService = providerSyncFinancialInstitutionService;
            _providerSyncAssetService = providerSyncAssetService;
            _assetPositionRepository = assetPositionRepository;
        }

        public async Task Sync(EnumProvider providerId)
        {
            IProviderService providerService = _providerServiceFactory.Get(providerId);

            var positions = await providerService.GetPositions();

            var financialInstitutions =
                await _providerSyncFinancialInstitutionService.SyncFinancialInstitutions(positions);

            var assets = await _providerSyncAssetService.SyncAssets(positions, financialInstitutions);

            var assetPosition =
                positions.Select(p => p.ToAssetPosition(assets.First(a => a.ExternalIdOnProvider == p.AssetId)));

            var tasks = assetPosition.Select(_assetPositionRepository.Add);

            await Task.WhenAll(tasks);

            // var movements = await providerService.GetMovements();
            // var events = await providerService.GetEvents();
        }
    }
}