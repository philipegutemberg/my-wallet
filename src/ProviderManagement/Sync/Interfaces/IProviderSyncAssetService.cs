using System.Collections.Generic;
using System.Threading.Tasks;
using ProviderManagement.Entities;
using ProviderManagement.Models;

namespace ProviderManagement.Sync.Interfaces
{
    internal interface IProviderSyncAssetService
    {
        Task<IEnumerable<AssetWithProvider>> SyncAssets(
            IEnumerable<ProviderAssetPosition> positions,
            IEnumerable<FinancialInstitutionWithProvider> financialInstitutionWithProviders);
    }
}