using Domain.Entities;

namespace Domain.Repositories
{
    public interface IFinancialInstitutionRepository
    {
        Task<FinancialInstitution> Add(FinancialInstitution financialInstitution);
    }
}