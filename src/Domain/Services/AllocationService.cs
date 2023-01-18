using Domain.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services;

internal class AllocationService : IAllocationService
{
    private readonly IAssetDimensionRepository _assetDimensionRepository;

    public AllocationService(IAssetDimensionRepository assetDimensionRepository)
    {
        _assetDimensionRepository = assetDimensionRepository;
    }

    public Task AssignAllocation(int assetDimensionId, decimal percentage)
    {
        throw new NotImplementedException();
    }

    public Task AssignDimensionParentToDimension(int assetDimensionId, int assetDimensionParentId, decimal percentage)
    {
        throw new NotImplementedException();
    }

    public Task AssignDimensionToAsset(int assetId, int dimensionId, decimal percentage)
    {
        throw new NotImplementedException();
    }
}