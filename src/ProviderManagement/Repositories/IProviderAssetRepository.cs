using ProviderManagement.Entities;

namespace ProviderManagement.Repositories
{
    public interface IProviderAssetRepository
    {
        Task Add(SyncableAssetWithProvider assetWithProvider);

        Task<IEnumerable<SyncableAssetWithProvider>> GetAll();
    }
}