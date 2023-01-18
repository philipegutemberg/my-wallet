using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAssetRepository
    {
        Task<Asset> Add(Asset asset);
    }
}