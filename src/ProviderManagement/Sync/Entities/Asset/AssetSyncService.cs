using Domain.Repositories;
using ProviderManagement.Entities;
using ProviderManagement.Repositories;
using ProviderManagement.Sync.Context;
using ProviderManagement.Sync.Interfaces;

namespace ProviderManagement.Sync.Entities.Asset;

internal class AssetSyncService : SyncServiceBase<SyncableAssetWithProvider>, IAssetSyncService
{
    private readonly IProviderAssetRepository _providerAssetRepository;
    private readonly IAssetRepository _assetRepository;

    public AssetSyncService(
        ISyncContext syncContext,
        ISyncableEntityService<SyncableAssetWithProvider> syncableEntityService,
        IProviderAssetRepository providerAssetRepository,
        IAssetRepository assetRepository)
        : base(syncContext, syncableEntityService)
    {
        _providerAssetRepository = providerAssetRepository;
        _assetRepository = assetRepository;
    }

    protected override async Task<IEnumerable<SyncableAssetWithProvider>> GetAllSaved() =>
        await _providerAssetRepository.GetAll();

    protected override async Task<SyncableAssetWithProvider> Insert(SyncableAssetWithProvider entity)
    {
        Domain.Entities.Asset inserted = await _assetRepository.Add(entity);
        entity.AssignId(inserted.Id);

        await _providerAssetRepository.Add(new SyncableAssetWithProvider(
            inserted.Id,
            entity.Name,
            entity.FinancialInstitutionId,
            (int)entity.ProviderId,
            entity.ExternalIdOnProvider
        ));

        return entity;
    }

    protected override string GetContextKey() => ContextKeys.Assets;
}