using System.Collections.Generic;
using System.Threading.Tasks;
using ProviderManagement.Entities;
using ProviderManagement.Models;

namespace ProviderManagement.Repositories
{
    public interface IProviderAssetRepository
    {
        Task Add(AssetWithProvider assetWithProvider);

        Task<IEnumerable<AssetWithProvider>> GetAll();
    }
}