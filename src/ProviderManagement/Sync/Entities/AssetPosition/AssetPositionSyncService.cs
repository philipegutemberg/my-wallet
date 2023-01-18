using Domain.Repositories;
using ProviderManagement.Entities;
using ProviderManagement.Sync.Context;
using ProviderManagement.Sync.Interfaces;

namespace ProviderManagement.Sync.Entities.AssetPosition;

internal class AssetPositionSyncService : SyncServiceBase<SyncableAssetPosition>, IAssetPositionSyncService
{
    private readonly IAssetPositionRepository _assetPositionRepository;

    public AssetPositionSyncService(
        ISyncContext syncContext,
        ISyncableEntityService<SyncableAssetPosition> syncableEntityService,
        IAssetPositionRepository assetPositionRepository)
        : base(syncContext, syncableEntityService)
    {
        _assetPositionRepository = assetPositionRepository;
    }

    protected override async Task BeforeSync() => await _assetPositionRepository.RemoveAll();

    protected override Task<IEnumerable<SyncableAssetPosition>> GetAllSaved() =>
        Task.FromResult(Enumerable.Empty<SyncableAssetPosition>());

    protected override async Task<SyncableAssetPosition> Insert(SyncableAssetPosition entity) =>
        new(await _assetPositionRepository.Add(entity));

    protected override string GetContextKey() => ContextKeys.Positions;
}