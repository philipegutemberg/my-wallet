using ProviderManagement.Entities;
using ProviderManagement.Models;
using ProviderManagement.Sync.Context;
using ProviderManagement.Sync.Interfaces;

namespace ProviderManagement.Sync.Entities.FinancialInstitution;

internal class FinancialInstitutionService : ISyncableEntityService<SyncableFinancialInstitutionWithProvider>
{
    private readonly ISyncContext _syncContext;

    public FinancialInstitutionService(ISyncContext syncContext)
    {
        _syncContext = syncContext;
    }

    public Task<IEnumerable<SyncableFinancialInstitutionWithProvider>> Get()
    {
        var positions = _syncContext.Get<IEnumerable<ProviderAssetPosition>>(ContextKeys.Positions);

        if (positions != null)
        {
            return Task.FromResult(
                positions
                    .Select(p =>
                        new SyncableFinancialInstitutionWithProvider(
                            p.FinancialInstitutionName,
                            p.ProviderId,
                            p.FinancialInstitutionId))
                    .DistinctBy(r => r.ExternalIdOnProvider)
            );
        }

        return Task.FromResult(Enumerable.Empty<SyncableFinancialInstitutionWithProvider>());
    }
}