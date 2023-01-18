using ProviderManagement.Entities;
using ProviderManagement.Models;
using ProviderManagement.Sync.Context;
using ProviderManagement.Sync.Interfaces;

namespace ProviderManagement.Sync.Entities.Asset;

internal class AssetService : ISyncableEntityService<SyncableAssetWithProvider>
{
    private readonly ISyncContext _syncContext;

    public AssetService(ISyncContext syncContext)
    {
        _syncContext = syncContext;
    }

    public Task<IEnumerable<SyncableAssetWithProvider>> Get()
    {
        var positions = _syncContext.Get<IEnumerable<ProviderAssetPosition>>(ContextKeys.Positions);
        var financialInstitutions = _syncContext.Get<IEnumerable<SyncableFinancialInstitutionWithProvider>>(ContextKeys.FinancialInstitutions);

        if (positions != null && financialInstitutions != null)
        {
            return Task.FromResult(
                positions.Select(p => new SyncableAssetWithProvider(
                        p.AssetName,
                        financialInstitutions.First(f => f.ExternalIdOnProvider == p.FinancialInstitutionId).Id,
                        null,
                        p.ProviderId,
                        p.AssetId))
                    .DistinctBy(r => r.ExternalIdOnProvider)
            );
        }

        return Task.FromResult(Enumerable.Empty<SyncableAssetWithProvider>());
    }
}