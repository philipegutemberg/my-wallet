using System.Collections.Generic;
using System.Threading.Tasks;
using ProviderManagement.Entities;

namespace ProviderManagement.Repositories
{
    public interface IProviderFinancialInstitutionRepository
    {
        Task Add(FinancialInstitutionWithProvider financialInstitutionWithProvider);

        Task<IEnumerable<FinancialInstitutionWithProvider>> GetAll();
    }
}