namespace Domain.Services.Interfaces;

public interface IAllocationService
{
    Task AssignAllocation(int portfolioDimensionId, decimal percentage);

    Task AssignDimensionParentToDimension(int portfolioDimensionId, int portfolioDimensionParentId, decimal percentage);

    Task AssignDimensionToAsset(int assetId, int dimensionId, decimal percentage);
}