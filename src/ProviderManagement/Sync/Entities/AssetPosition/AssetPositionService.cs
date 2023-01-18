using ProviderManagement.Entities;
using ProviderManagement.Models;
using ProviderManagement.Sync.Context;
using ProviderManagement.Sync.Interfaces;

namespace ProviderManagement.Sync.Entities.AssetPosition;

internal class AssetPositionService : ISyncableEntityService<SyncableAssetPosition>
{
    private readonly ISyncContext _syncContext;

    public AssetPositionService(ISyncContext syncContext)
    {
        _syncContext = syncContext;
    }

    public Task<IEnumerable<SyncableAssetPosition>> Get()
    {
        var positions = _syncContext.Get<IEnumerable<ProviderAssetPosition>>(ContextKeys.Positions);
        var assets = _syncContext.Get<IEnumerable<SyncableAssetWithProvider>>(ContextKeys.Assets);

        if (positions != null && assets != null)
        {
            return Task.FromResult(
                positions.Where(p => p.FinancialPosition > 0).Select(p =>
                    p.ToSyncableAssetPosition(assets.First(a => a.ExternalIdOnProvider == p.AssetId)))
            );
        }

        return Task.FromResult(Enumerable.Empty<SyncableAssetPosition>());
    }
}