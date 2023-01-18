using Domain.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services;

internal class AllocationService : IAllocationService
{
    private readonly IPortfolioDimensionRepository _portfolioDimensionRepository;

    public AllocationService(IPortfolioDimensionRepository portfolioDimensionRepository)
    {
        _portfolioDimensionRepository = portfolioDimensionRepository;
    }

    public Task AssignAllocation(int portfolioDimensionId, decimal percentage)
    {
        throw new NotImplementedException();
    }

    public Task AssignDimensionParentToDimension(int portfolioDimensionId, int portfolioDimensionParentId, decimal percentage)
    {
        throw new NotImplementedException();
    }

    public Task AssignDimensionToAsset(int assetId, int dimensionId, decimal percentage)
    {
        throw new NotImplementedException();
    }
}