using Domain.Repositories;
using ProviderManagement.Entities;
using ProviderManagement.Repositories;
using ProviderManagement.Sync.Context;
using ProviderManagement.Sync.Interfaces;

namespace ProviderManagement.Sync.Entities.FinancialInstitution;

internal class FinancialInstitutionSyncService : SyncServiceBase<SyncableFinancialInstitutionWithProvider>, IFinancialInstitutionSyncService
{
    private readonly IProviderFinancialInstitutionRepository _providerFinancialInstitutionRepository;
    private readonly IFinancialInstitutionRepository _financialInstitutionRepository;

    public FinancialInstitutionSyncService(
        ISyncContext syncContext,
        ISyncableEntityService<SyncableFinancialInstitutionWithProvider> syncableEntityService,
        IProviderFinancialInstitutionRepository providerFinancialInstitutionRepository,
        IFinancialInstitutionRepository financialInstitutionRepository)
        : base(syncContext, syncableEntityService)
    {
        _providerFinancialInstitutionRepository = providerFinancialInstitutionRepository;
        _financialInstitutionRepository = financialInstitutionRepository;
    }

    protected override async Task<IEnumerable<SyncableFinancialInstitutionWithProvider>> GetAllSaved() =>
        await _providerFinancialInstitutionRepository.GetAll();

    protected override async Task<SyncableFinancialInstitutionWithProvider> Insert(SyncableFinancialInstitutionWithProvider entity)
    {
        Domain.Entities.FinancialInstitution inserted = await _financialInstitutionRepository.Add(entity);
        entity.AssignId(inserted.Id);

        await _providerFinancialInstitutionRepository.Add(new SyncableFinancialInstitutionWithProvider(
            inserted.Id,
            entity.Name,
            (int)entity.ProviderId,
            entity.ExternalIdOnProvider
        ));

        return entity;
    }

    protected override string GetContextKey() => ContextKeys.FinancialInstitutions;
}