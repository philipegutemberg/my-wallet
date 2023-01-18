using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAssetRepository
    {
        Task<Asset> Add(Asset asset);

        Task<IEnumerable<Asset>> GetAll();

        Task<Asset> AssignPortfolioDimension(int assetId, int portfolioDimensionId);
    }
}