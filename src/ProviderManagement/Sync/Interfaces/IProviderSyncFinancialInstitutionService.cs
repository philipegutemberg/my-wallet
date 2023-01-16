using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using ProviderManagement.Entities;
using ProviderManagement.Models;

namespace ProviderManagement.Sync.Interfaces
{
    internal interface IProviderSyncFinancialInstitutionService
    {
        Task<IEnumerable<FinancialInstitutionWithProvider>> SyncFinancialInstitutions(IEnumerable<ProviderAssetPosition> positions);
    }
}