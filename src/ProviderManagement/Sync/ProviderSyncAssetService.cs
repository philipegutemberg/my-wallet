using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using ProviderManagement.Entities;
using ProviderManagement.Models;
using ProviderManagement.Repositories;
using ProviderManagement.Sync.Interfaces;

namespace ProviderManagement.Sync
{
    internal class ProviderSyncAssetService : IProviderSyncAssetService
    {
        private readonly IProviderAssetRepository _providerAssetRepository;
        private readonly IAssetRepository _assetRepository;

        public ProviderSyncAssetService(IProviderAssetRepository providerAssetRepository, IAssetRepository assetRepository)
        {
            _providerAssetRepository = providerAssetRepository;
            _assetRepository = assetRepository;
        }

        public async Task<IEnumerable<AssetWithProvider>> SyncAssets(
            IEnumerable<ProviderAssetPosition> positions,
            IEnumerable<FinancialInstitutionWithProvider> financialInstitutionWithProviders)
        {
            IEnumerable<AssetWithProvider> returnedAssets = GetReturnedAssets(positions, financialInstitutionWithProviders);

            IEnumerable<AssetWithProvider> savedProviderAssets =
                await _providerAssetRepository.GetAll();

            IEnumerable<AssetWithProvider> toBeInserted =
                returnedAssets.Where(i =>
                    savedProviderAssets.All(spi => spi.ExternalIdOnProvider != i.ExternalIdOnProvider));

            return await Insert(toBeInserted);
        }

        private async Task<IEnumerable<AssetWithProvider>> Insert(IEnumerable<AssetWithProvider> assetWithProviders) =>
            await Task.WhenAll(assetWithProviders.Select(Insert));

        private async Task<AssetWithProvider> Insert(AssetWithProvider assetWithProvider)
        {
            Asset inserted = await _assetRepository.Add(assetWithProvider);
            assetWithProvider.AssignId(inserted.Id);

            await _providerAssetRepository.Add(new AssetWithProvider(
                inserted.Id,
                assetWithProvider.Name,
                assetWithProvider.FinancialInstitutionId,
                assetWithProvider.ProviderId,
                assetWithProvider.ExternalIdOnProvider
            ));

            return assetWithProvider;
        }

        private IEnumerable<AssetWithProvider> GetReturnedAssets(
            IEnumerable<ProviderAssetPosition> positions,
            IEnumerable<FinancialInstitutionWithProvider> financialInstitutionWithProviders) =>
            positions
                .Select(p => new AssetWithProvider(
                    p.AssetName,
                    financialInstitutionWithProviders.First(f => f.ExternalIdOnProvider == p.FinancialInstitutionId).Id,
                    p.ProviderId,
                    p.FinancialInstitutionId))
                .DistinctBy(r => r.ExternalIdOnProvider);
    }
}