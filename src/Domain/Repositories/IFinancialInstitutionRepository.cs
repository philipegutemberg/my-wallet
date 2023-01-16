using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IFinancialInstitutionRepository
    {
        Task<FinancialInstitution> Add(FinancialInstitution financialInstitution);
    }
}