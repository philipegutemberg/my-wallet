using Domain.Entities;

namespace Domain.Repositories;

public interface IAssetDimensionRepository
{
    Task<AssetDimension> Add(AssetDimension assetDimension);

    Task<IEnumerable<AssetDimension>> GetAll();

    Task<AssetDimension> Get(int dimensionId);

    Task<AssetDimension> AssignParent(int dimensionId, int parentDimensionId);
}