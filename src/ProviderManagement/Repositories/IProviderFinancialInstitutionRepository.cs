using ProviderManagement.Entities;

namespace ProviderManagement.Repositories
{
    public interface IProviderFinancialInstitutionRepository
    {
        Task Add(SyncableFinancialInstitutionWithProvider financialInstitutionWithProvider);

        Task<IEnumerable<SyncableFinancialInstitutionWithProvider>> GetAll();
    }
}